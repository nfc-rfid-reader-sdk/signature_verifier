using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

namespace SignatureVerifier
{
    public partial class frmMain : Form
    {
        ECPrivateKeyParameters mPrivateKey;
        X9ECParameters mECCurve;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = this.Text + " v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            cbRSAKeyLength.SelectedIndex = 8;

            cbECName.SelectedIndex = 0;
            cbECKeyLength.SelectedIndex = 0;

            cbDigest.SelectedIndex = 0;
            cbCipher.SelectedIndex = 0;

            //Oid o = new Oid("1.2.840.10045.2.1");
            //MessageBox.Show(o.FriendlyName);
        }

        private void llbDLogicURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.d-logic.net/nfc-rfid-reader-sdk/");
        }

        private byte[] zeroPadArray(byte[] theArray, byte paddingVal, Int32 paddingSize)
        {
            byte[] newArray = new byte[theArray.Length + paddingSize];
            for (UInt32 i = 0; i < paddingSize; i++)
            {
                newArray[i] = paddingVal;
            }
            theArray.CopyTo(newArray, paddingSize);
            return newArray;
        }

        //======================================================================================================================
        // RSA Keys page:
        //======================================================================================================================
        private void btnRSAImportP12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PKCS#12 files (*.p12;*.pfx)|*.p12;*.pfx|All files (*.*)|*.*";
            //dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select the cert file";

            Asn1InputStream decoder = null;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                frmPassword dlgPasswd = new frmPassword();
                if (dlgPasswd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load your certificate from p12 file
                        X509Certificate2 certificate = new X509Certificate2(dialog.FileName, dlgPasswd.password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                        //RSACryptoServiceProvider pub_key = (RSACryptoServiceProvider)certificate.PublicKey.Key;
                        PublicKey pub_key = certificate.PublicKey;
                        //certificate.Dispose(); ToDo: See if needed

                        if (!pub_key.EncodedKeyValue.Oid.FriendlyName.Equals("RSA"))
                        {
                            MessageBox.Show("Selected cert. file doesn't contain RSA public key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Int32 key_len = cbRSAKeyLength.FindStringExact(pub_key.Key.KeySize.ToString());
                        if (key_len < 0)
                        {
                            MessageBox.Show("Unsupported key length of " + pub_key.Key.KeySize + "bytes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        cbRSAKeyLength.SelectedIndex = key_len;
                        key_len = pub_key.Key.KeySize;

                        decoder = new Asn1InputStream(new MemoryStream(pub_key.EncodedKeyValue.RawData));
                        DerSequence seq = (DerSequence)decoder.ReadObject();
                        DerInteger rr = (DerInteger)seq[0];
                        DerInteger ss = (DerInteger)seq[1];
                        byte[] br = rr.PositiveValue.ToByteArray();
                        byte[] bs = ss.PositiveValue.ToByteArray();
                        
                        // Remove leading zeros:
                        while (br[0] == 0 && br.Length > key_len / 8)
                        {
                            br = br.Skip(1).ToArray();
                        }
                        while (bs[0] == 0 && br.Length > 0)
                        {
                            bs = br.Skip(1).ToArray();
                        }
                        tbRSAModulus.Text = BitConverter.ToString(br).Replace("-", "");
                        tbRSAPubExp.Text = BitConverter.ToString(bs).Replace("-", "");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (decoder != null)
                            decoder.Close();
                    }
                }
            }
        }

        private void btnRSAImportPem_Click(object sender, EventArgs e)
        {
            Int32 key_len, key_idx;
            byte[] modulus;
            byte[] exponent;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PEM files (*.pem;*.crt;*.cer)|*.pem;*.crt;*.cer|All files (*.*)|*.*";
            //dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select the PEM file";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load your certificate from PEM file
                    TextReader fileStream = System.IO.File.OpenText(dialog.FileName);
                    PemReader pemReader = new Org.BouncyCastle.OpenSsl.PemReader(fileStream);
                    object KeyParameter = pemReader.ReadObject();

                    if (KeyParameter.GetType() == typeof(Org.BouncyCastle.X509.X509Certificate))
                    {
                        // Load your certificate:
                        X509Certificate2 certificate = new X509Certificate2(dialog.FileName);
                        KeyParameter = Org.BouncyCastle.Security.DotNetUtilities.GetRsaPublicKey(certificate.GetRSAPublicKey());
                        //certificate.Dispose(); ToDo: See if needed
                    }

                    if (KeyParameter.GetType() == typeof(Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters))
                    {
                        key_len = ((RsaPrivateCrtKeyParameters)KeyParameter).Modulus.BitLength;
                        modulus = ((RsaPrivateCrtKeyParameters)KeyParameter).Modulus.ToByteArray();
                        exponent = ((RsaPrivateCrtKeyParameters)KeyParameter).PublicExponent.ToByteArray();
                    }
                    else if (KeyParameter.GetType() == typeof(Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair))
                    {
                        key_len = ((RsaKeyParameters)((AsymmetricCipherKeyPair)KeyParameter).Public).Modulus.BitLength;
                        modulus = ((RsaKeyParameters)((AsymmetricCipherKeyPair)KeyParameter).Public).Modulus.ToByteArray();
                        exponent = ((RsaKeyParameters)((AsymmetricCipherKeyPair)KeyParameter).Public).Exponent.ToByteArray();
                    }
                    else if (KeyParameter.GetType() == typeof(Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters))
                    {
                        key_len = ((RsaKeyParameters)KeyParameter).Modulus.BitLength;
                        modulus = ((RsaKeyParameters)KeyParameter).Modulus.ToByteArray();
                        exponent = ((RsaKeyParameters)KeyParameter).Exponent.ToByteArray();
                    }
                    else
                    {
                        MessageBox.Show("File doesn't contain RSA public key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //? Org.BouncyCastle.Crypto.AsymmetricKeyParameter
                    //? Org.BouncyCastle.Crypto.Parameters.RsaBlindingParameters
                    //? Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters
                    //MessageBox.Show(KeyParameter.GetType().ToString());

                    key_idx = cbRSAKeyLength.FindStringExact(key_len.ToString());
                    if (key_idx < 0)
                    {
                        MessageBox.Show("Unsupported key length of " + key_len + "bytes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cbRSAKeyLength.SelectedIndex = key_idx;

                    // Remove leading zeros:
                    while (modulus[0] == 0 && modulus.Length > key_len / 8)
                    {
                        modulus = modulus.Skip(1).ToArray();
                    }
                    while (exponent[0] == 0 && exponent.Length > 0)
                    {
                        exponent = exponent.Skip(1).ToArray();
                    }
                    tbRSAModulus.Text = BitConverter.ToString(modulus).Replace("-", "");
                    tbRSAPubExp.Text = BitConverter.ToString(exponent).Replace("-", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //======================================================================================================================
        // EC Keys page:
        //======================================================================================================================
        void populateECDomainParameters(string curve_name)
        {
            byte[] barr1;
            Int32 key_bytes_len;
            mECCurve = SecNamedCurves.GetByName(curve_name);

            try
            {
                key_bytes_len = (mECCurve.Curve.FieldSize + 7) / 8;

                if (mECCurve.Curve.GetType() == typeof(FpCurve))
                {
                    rbECFieldPrime.Checked = true;
                    barr1 = mECCurve.Curve.Field.Characteristic.ToByteArray();
                    if (key_bytes_len > barr1.Length)
                        barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                    while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                    {
                        barr1 = barr1.Skip(1).ToArray();
                    }
                    tbECParamPrime.Text = BitConverter.ToString(barr1).Replace("-", "");
                }
                else if (mECCurve.Curve.GetType() == typeof(F2mCurve))
                {
                    rbECFieldBinary.Checked = true;
                    populateECReductionPolynomial(!((F2mCurve)mECCurve.Curve).IsTrinomial(),
                            (ushort)mECCurve.Curve.FieldSize,
                            (ushort)((F2mCurve)mECCurve.Curve).K3,
                            (ushort)((F2mCurve)mECCurve.Curve).K2,
                            (ushort)((F2mCurve)mECCurve.Curve).K1);
                }

                barr1 = mECCurve.Curve.A.ToBigInteger().ToByteArray();
                if (key_bytes_len > barr1.Length)
                    barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                {
                    barr1 = barr1.Skip(1).ToArray();
                }
                tbECParamA.Text = BitConverter.ToString(barr1).Replace("-", "");

                barr1 = mECCurve.Curve.B.ToBigInteger().ToByteArray();
                if (key_bytes_len > barr1.Length)
                    barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                {
                    barr1 = barr1.Skip(1).ToArray();
                }
                tbECParamB.Text = BitConverter.ToString(barr1).Replace("-", "");

                barr1 = mECCurve.G.XCoord.ToBigInteger().ToByteArray();
                if (key_bytes_len > barr1.Length)
                    barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                {
                    barr1 = barr1.Skip(1).ToArray();
                }
                tbECParamG.Text = "04" + BitConverter.ToString(barr1).Replace("-", "");

                barr1 = mECCurve.G.YCoord.ToBigInteger().ToByteArray();
                if (key_bytes_len > barr1.Length)
                    barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                {
                    barr1 = barr1.Skip(1).ToArray();
                }
                tbECParamG.Text += BitConverter.ToString(barr1).Replace("-", "");

                barr1 = mECCurve.N.ToByteArray();
                if (key_bytes_len > barr1.Length)
                    barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                {
                    barr1 = barr1.Skip(1).ToArray();
                }
                tbECParamR.Text = BitConverter.ToString(barr1).Replace("-", "");

                tbECParamK.Text = mECCurve.H.ToString(); // mECCurve.Curve.Cofactor.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearECReductionPolynomial()
        {
            rtbECReductionPolynomial.Clear();
            //richTextBox1.SelectionColor = Color.Black;
            rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 10, FontStyle.Italic);
            rtbECReductionPolynomial.SelectedText = " f(x) = ";
        }

        private void populateECReductionPolynomial(Boolean isPentanomial, UInt16 m, UInt16 e1, UInt16 e2, UInt16 e3)
        {
            tbECParamE1.Enabled = true;

            rtbECReductionPolynomial.Clear();
            //richTextBox1.SelectionColor = Color.Black;
            rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 10, FontStyle.Italic);
            rtbECReductionPolynomial.SelectedText = " f(x) = x";
            // superscripted text...
            rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 7, FontStyle.Italic);
            rtbECReductionPolynomial.SelectionCharOffset = 8;
            rtbECReductionPolynomial.SelectedText = m.ToString();
            // normal text...
            rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 10, FontStyle.Italic);
            rtbECReductionPolynomial.SelectionCharOffset = 0;
            rtbECReductionPolynomial.SelectedText = " + x";

            if (isPentanomial)
            {
                lbECParamE1.Text = "e1:";
                tbECParamE1.Text = e1.ToString();
                lbECParamE2.Enabled = true;
                lbECParamE3.Enabled = true;
                tbECParamE2.Enabled = true;
                tbECParamE3.Enabled = true;
                tbECParamE2.Text = e2.ToString();
                tbECParamE3.Text = e3.ToString();

                // superscripted text...
                rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 7, FontStyle.Italic);
                rtbECReductionPolynomial.SelectionCharOffset = 8;
                rtbECReductionPolynomial.SelectedText = e1.ToString();
                // normal text...
                rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 10, FontStyle.Italic);
                rtbECReductionPolynomial.SelectionCharOffset = 0;
                rtbECReductionPolynomial.SelectedText = " + x";
                // superscripted text...
                rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 7, FontStyle.Italic);
                rtbECReductionPolynomial.SelectionCharOffset = 8;
                rtbECReductionPolynomial.SelectedText = e2.ToString();
                // normal text...
                rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 10, FontStyle.Italic);
                rtbECReductionPolynomial.SelectionCharOffset = 0;
                rtbECReductionPolynomial.SelectedText = " + x";
                // superscripted text...
                rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 7, FontStyle.Italic);
                rtbECReductionPolynomial.SelectionCharOffset = 8;
                rtbECReductionPolynomial.SelectedText = e3.ToString();
            }
            else
            {
                lbECParamE1.Text = "e:";
                tbECParamE1.Text = e3.ToString();
                tbECParamE2.Clear();
                tbECParamE3.Clear();
                tbECParamE2.Enabled = false;
                tbECParamE3.Enabled = false;
                lbECParamE2.Enabled = false;
                lbECParamE3.Enabled = false;

                // superscripted text...
                rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 7, FontStyle.Italic);
                rtbECReductionPolynomial.SelectionCharOffset = 8;
                rtbECReductionPolynomial.SelectedText = e3.ToString();
            }
            // normal text...
            rtbECReductionPolynomial.SelectionFont = new Font("Times New Roman", 10, FontStyle.Italic);
            rtbECReductionPolynomial.SelectionCharOffset = 0;
            rtbECReductionPolynomial.SelectedText = " + 1";
        }

        private void rbECFieldPrime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbECFieldPrime.Checked)
            {
                tbECParamPrime.Enabled = true;
                clearECReductionPolynomial();
                tbECParamE1.Clear();
                tbECParamE2.Clear();
                tbECParamE3.Clear();
                gbECReductionPolynomial.Enabled = false;
            }
        }

        private void rbECFieldBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (rbECFieldBinary.Checked)
            {
                tbECParamPrime.Enabled = false;
                tbECParamPrime.Clear();
                gbECReductionPolynomial.Enabled = true;
            }
        }

        private bool m_gate_cbECKeyLength = false;
        private int mECNameCurrComboIndex = 0;
        private void cbECName_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_gate_cbECKeyLength = true;

            if (mECNameCurrComboIndex != cbECName.SelectedIndex)
            {
                mECNameCurrComboIndex = cbECName.SelectedIndex;
                tbECPubKey.Text = "";
            }

            if (cbECName.SelectedIndex < 15)
            {
                rbECFieldPrime.Checked = true;
            }
            else
            {
                rbECFieldBinary.Checked = true;
            }
            switch (cbECName.SelectedIndex)
            {
                case 0:
                case 1:

                    cbECKeyLength.SelectedIndex = 0;
                    break;
                case 2:
                case 3:
                    cbECKeyLength.SelectedIndex = 2;
                    break;
                case 4:
                case 5:
                case 6:
                    cbECKeyLength.SelectedIndex = 4;
                    break;
                case 7:
                case 8:
                    cbECKeyLength.SelectedIndex = 6;
                    break;
                case 9:
                case 10:
                    cbECKeyLength.SelectedIndex = 8;
                    break;
                case 11:
                case 12:
                    cbECKeyLength.SelectedIndex = 11;
                    break;
                case 13:
                    cbECKeyLength.SelectedIndex = 13;
                    break;
                case 14:
                    cbECKeyLength.SelectedIndex = 15;
                    break;
                case 15:
                case 16:
                    cbECKeyLength.SelectedIndex = 1;
                    break;
                case 17:
                case 18:
                    cbECKeyLength.SelectedIndex = 3;
                    break;
                case 19:
                case 20:
                case 21:
                    cbECKeyLength.SelectedIndex = 5;
                    break;
                case 22:
                case 23:
                    cbECKeyLength.SelectedIndex = 7;
                    break;
                case 24:
                case 25:
                    cbECKeyLength.SelectedIndex = 9;
                    break;

                case 26:
                    cbECKeyLength.SelectedIndex = 10;
                    break;
                case 27:
                case 28:
                    cbECKeyLength.SelectedIndex = 12;
                    break;
                case 29:
                case 30:
                    cbECKeyLength.SelectedIndex = 14;
                    break;
                case 31:
                case 32:
                    cbECKeyLength.SelectedIndex = 16;
                    break;
            }
            populateECDomainParameters(cbECName.Text);
            m_gate_cbECKeyLength = false;
        }

        private void cbECKeyLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_gate_cbECKeyLength)
                return;

            switch (cbECKeyLength.SelectedIndex)
            {
                case 0:
                    if (cbECName.SelectedIndex != 1)
                        cbECName.SelectedIndex = 0;
                    break;
                case 1:
                    if (cbECName.SelectedIndex != 16)
                        cbECName.SelectedIndex = 15;
                    break;
                case 2:
                    if (cbECName.SelectedIndex != 3)
                        cbECName.SelectedIndex = 2;
                    break;
                case 3:
                    if (cbECName.SelectedIndex != 18)
                        cbECName.SelectedIndex = 17;
                    break;
                case 4:
                    if (cbECName.SelectedIndex != 5 && cbECName.SelectedIndex != 6)
                        cbECName.SelectedIndex = 4;
                    break;
                case 5:
                    if (cbECName.SelectedIndex != 20 && cbECName.SelectedIndex != 21)
                        cbECName.SelectedIndex = 19;
                    break;
                case 6:
                    if (cbECName.SelectedIndex != 8)
                        cbECName.SelectedIndex = 7;
                    break;
                case 7:
                    if (cbECName.SelectedIndex != 23)
                        cbECName.SelectedIndex = 22;
                    break;
                case 8:
                    if (cbECName.SelectedIndex != 10)
                        cbECName.SelectedIndex = 9;
                    break;
                case 9:
                    if (cbECName.SelectedIndex != 25)
                        cbECName.SelectedIndex = 24;
                    break;
                case 10:
                    cbECName.SelectedIndex = 26;
                    break;
                case 11:
                    if (cbECName.SelectedIndex != 12)
                        cbECName.SelectedIndex = 11;
                    break;
                case 12:
                    if (cbECName.SelectedIndex != 28)
                        cbECName.SelectedIndex = 27;
                    break;
                case 13:
                    cbECName.SelectedIndex = 13;
                    break;
                case 14:
                    if (cbECName.SelectedIndex != 30)
                        cbECName.SelectedIndex = 29;
                    break;
                case 15:
                    cbECName.SelectedIndex = 14;
                    break;
                case 16:
                    if (cbECName.SelectedIndex != 32)
                        cbECName.SelectedIndex = 31;
                    break;
            }
        }

        private void btnECImportP12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PKCS#12 files (*.p12;*.pfx)|*.p12;*.pfx|All files (*.*)|*.*";
            //dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select the cert file";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                frmPassword dlgPasswd = new frmPassword();
                if (dlgPasswd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load your certificate from p12 file
                        X509Certificate2 certificate = new X509Certificate2(dialog.FileName, dlgPasswd.password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                        //RSACryptoServiceProvider pub_key = (RSACryptoServiceProvider)certificate.PublicKey.Key;
                        PublicKey pub_key = certificate.PublicKey;

                        if (pub_key.EncodedKeyValue.Oid.FriendlyName.Equals("ECC"))
                        {
                            var parser = new X509CertificateParser();
                            // Load your certificate
                            var bouncyCertificate = parser.ReadCertificate(certificate.RawData);
                            //certificate.Dispose(); ToDo: See if needed

                            string curve_name = SecNamedCurves.GetName(
                                (DerObjectIdentifier)DerObjectIdentifier.FromByteArray(
                                    bouncyCertificate.CertificateStructure.SubjectPublicKeyInfo.AlgorithmID.Parameters.GetDerEncoded()
                                    )
                                );

                            if (cbECName.Items.Contains(curve_name))
                            {
                                int index = cbECName.FindString(curve_name);
                                cbECName.SelectedIndex = index;
                            }
                            else
                                throw new Exception("Unknown ECC Parameters in certificate.");

                            tbECPubKey.Text = BitConverter.ToString(
                                bouncyCertificate.CertificateStructure.SubjectPublicKeyInfo.PublicKeyData.GetBytes()
                                ).Replace("-", "");
                        }
                        else
                        {
                            MessageBox.Show("File doesn't contain EC public key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnECImportFromPem_Click(object sender, EventArgs e)
        {
            byte[] barr1, barr2;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PEM files (*.pem;*.crt;*.cer)|*.pem;*.crt;*.cer|All files (*.*)|*.*";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select the PEM file";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // ToDo: Find beter strategy to open Org.BouncyCastle.X509.X509Certificate

                    // Load your certificate from PEM file
                    TextReader fileStream = System.IO.File.OpenText(dialog.FileName);
                    PemReader pemReader = new Org.BouncyCastle.OpenSsl.PemReader(fileStream);
                    object KeyParameter = pemReader.ReadObject();

                    if (KeyParameter.GetType() == typeof(Org.BouncyCastle.Crypto.Parameters.ECPublicKeyParameters))
                    {
                        int idx = 0;
                        foreach (string s in cbECName.Items)
                        {
                            var EC = SecNamedCurves.GetByName(s);
                            if (EC.Curve.Equals(((ECPublicKeyParameters)KeyParameter).Parameters.Curve))
                                break;
                            idx++;
                        }
                        if ((idx + 1) >= cbECName.Items.Count)
                            throw new Exception("Unknown ECC Parameters in pem file.");

                        cbECName.SelectedIndex = idx;

                        var publicKeyParam = ((ECPublicKeyParameters)KeyParameter);
                        int key_bytes_len = (publicKeyParam.Parameters.Curve.FieldSize + 7) / 8;
                        barr1 = publicKeyParam.Q.XCoord.ToBigInteger().ToByteArray();
                        if (key_bytes_len > barr1.Length)
                            barr1 = zeroPadArray(barr1, 0, key_bytes_len - barr1.Length);
                        while (barr1[0] == 0 && barr1.Length > key_bytes_len)
                        {
                            barr1 = barr1.Skip(1).ToArray();
                        }
                        barr2 = publicKeyParam.Q.YCoord.ToBigInteger().ToByteArray();
                        if (key_bytes_len > barr2.Length)
                            barr2 = zeroPadArray(barr2, 0, key_bytes_len - barr2.Length);
                        while (barr2[0] == 0 && barr2.Length > key_bytes_len)
                        {
                            barr2 = barr2.Skip(1).ToArray();
                        }
                        tbECPubKey.Text = "04" + BitConverter.ToString(barr1).Replace("-", "") + BitConverter.ToString(barr2).Replace("-", "");
                    }
                    else if (KeyParameter.GetType() == typeof(Org.BouncyCastle.X509.X509Certificate))
                    {
                        var parser = new X509CertificateParser();
                        // Load your certificate
                        X509Certificate2 certificate = new X509Certificate2(dialog.FileName);
                        var bouncyCertificate = parser.ReadCertificate(certificate.RawData);
                        //certificate.Dispose(); ToDo: See if needed

                        string curve_name = SecNamedCurves.GetName(
                            (DerObjectIdentifier)DerObjectIdentifier.FromByteArray(
                                bouncyCertificate.CertificateStructure.SubjectPublicKeyInfo.AlgorithmID.Parameters.GetDerEncoded()
                                )
                            );

                        if (cbECName.Items.Contains(curve_name))
                        {
                            int index = cbECName.FindString(curve_name);
                            cbECName.SelectedIndex = index;
                        }
                        else
                            throw new Exception("Unknown ECC Parameters in certificate.");

                        tbECPubKey.Text = BitConverter.ToString(
                            bouncyCertificate.CertificateStructure.SubjectPublicKeyInfo.PublicKeyData.GetBytes()
                            ).Replace("-", "");
                    }
                    else
                    {
                        MessageBox.Show("File doesn't contain EC public key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //======================================================================================================================
        // Signature page:
        //======================================================================================================================
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // The URI to sign.
                string resourceToSign = "file:///test.txt";

                // The name of the file to which to save the XML signature.
                string XmlFileName = "signature.xml";

                // Generate a signing key.
                RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

                //Console.WriteLine("Signing: {0}", resourceToSign);

                // Sign the detached resourceand save the signature in an XML file.
                SignDetachedResource(resourceToSign, XmlFileName, Key);

                //Console.WriteLine("XML Signature was succesfully computed and saved to {0}.", XmlFileName);

                /*
                                // Verify the signature of the signed XML.
                                Console.WriteLine("Verifying signature...");

                                //Verify the XML signature in the XML file against the key.
                                //bool result = VerifyDetachedSignatureWithRSAPublicKey(XmlFileName, Key);
                                bool result = VerifyDetachedSignature(XmlFileName);

                                // Display the results of the signature verification to 
                                // the console.
                                if (result)
                                {
                                    Console.WriteLine("The XML signature is valid.");
                                }
                                else
                                {
                                    Console.WriteLine("The XML signature is not valid.");
                                }
                */
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Sign an XML file and save the signature in a new file. This method does not  
        // save the public key within the XML file.  This file cannot be verified unless  
        // the verifying code has the key with which it was signed.
        public static void SignDetachedResource(string URIString, string XmlSigFileName, RSA RSAKey)
        {
            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml();

            // Assign the DSA key to the SignedXml object.
            signedXml.SigningKey = RSAKey;

            // Create a reference to be signed.
            Reference reference = new Reference();

            // Add the passed URI to the reference object.
            reference.Uri = URIString;

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Add a DSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)RSAKey));
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Save the signed XML document to a file specified
            // using the passed string.
            XmlTextWriter xmltw = new XmlTextWriter(XmlSigFileName, new UTF8Encoding(false));
            xmlDigitalSignature.WriteTo(xmltw);
            xmltw.Close();
        }

        // Verify the signature of an XML file against an asymetric 
        // algorithm and return the result.
        public static Boolean VerifyDetachedSignatureWithRSAPublicKey(string XmlSigFileName, RSA Key)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Load the passedXML file into the document.
            xmlDocument.Load(XmlSigFileName);

            // Create a new SignedXml object.
            SignedXml signedXml = new SignedXml();

            // Find the "Signature" node and create a new XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

            // Load the signature node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature against the passed asymetric key
            // and return the result.
            return signedXml.CheckSignature(Key);
        }

        //Verify the siganature of an XML file
        public static Boolean VerifyDetachedSignature(String XmlSigFileName)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Load the passedXML file into the document.
            xmlDocument.Load(XmlSigFileName);

            // Find the "KeyValue" node,
            // get the public key and use the key to initialize
            // a RSACryptoServiceProvider object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("KeyValue");
            RSACryptoServiceProvider Key = new RSACryptoServiceProvider();
            Key.FromXmlString(nodeList[0].InnerXml);

            // Check the signature against the RSACryptoServiceProvider object
            // and return the result.
            return VerifyDetachedSignatureWithRSAPublicKey(XmlSigFileName, Key);
        }

        //======================================================================================================================
        // Verify Signature page:
        //======================================================================================================================
        enum RADIX
        {
            Hex,
            Base64,
            ASCII,
            Exception_FromFile
        };
        RADIX mMessageRadix = RADIX.Hex;
        RADIX mSignatureRadix = RADIX.Hex;

        private void tbMessageRadixChanged(object sender, EventArgs e)
        {
            bool showExceptionMessage = true;
            try
            {
                if (sender == rbMessageFromFile)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "All files (*.*)|*.*";
                    //dialog.InitialDirectory = @"C:\";
                    dialog.Title = "Please select file for signing";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        tbMessage.ReadOnly = true;
                        tbMessage.BackColor = SystemColors.Info;
                        tbMessage.Text = dialog.FileName;
                        mMessageRadix = RADIX.Exception_FromFile;
                    }
                    else
                    {
                        showExceptionMessage = false;
                        throw new Exception("File selection canceled");
                    }
                }
                else
                {
                    switch (mMessageRadix) // from radix
                    {
                        case RADIX.Hex:
                            if (sender == rbMessageBase64)
                            {
                                tbMessage.Text = Convert.ToBase64String(Hex.Decode(tbMessage.Text));
                                mMessageRadix = RADIX.Base64;
                            }
                            else if (sender == rbMessageAscii)
                            {
                                tbMessage.Text = Encoding.ASCII.GetString(Hex.Decode(tbMessage.Text));
                                mMessageRadix = RADIX.ASCII;
                            }
                            break;
                        case RADIX.Base64:
                            if (sender == rbMessageHex)
                            {
                                tbMessage.Text = BitConverter.ToString(Convert.FromBase64String(tbMessage.Text)).Replace("-", "");
                                mMessageRadix = RADIX.Hex;
                            }
                            else if (sender == rbMessageAscii)
                            {
                                tbMessage.Text = Encoding.ASCII.GetString(Convert.FromBase64String(tbMessage.Text));
                                mMessageRadix = RADIX.ASCII;
                            }
                            break;
                        case RADIX.ASCII:
                            if (sender == rbMessageHex)
                            {
                                tbMessage.Text = BitConverter.ToString(Encoding.ASCII.GetBytes(tbMessage.Text)).Replace("-", "");
                                mMessageRadix = RADIX.Hex;
                            }
                            else if (sender == rbMessageBase64)
                            {
                                tbMessage.Text = Convert.ToBase64String(Encoding.ASCII.GetBytes(tbMessage.Text));
                                mMessageRadix = RADIX.Base64;
                            }
                            break;
                        case RADIX.Exception_FromFile:
                            tbMessage.BackColor = SystemColors.Window;
                            tbMessage.Text = "";
                            tbMessage.ReadOnly = false;
                            if (sender == rbMessageHex)
                                mMessageRadix = RADIX.Hex;
                            else if (sender == rbMessageBase64)
                                mMessageRadix = RADIX.Base64;
                            else if (sender == rbMessageAscii)
                                mMessageRadix = RADIX.ASCII;

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                switch (mMessageRadix)
                {
                    case RADIX.Hex:
                        rbMessageHex.Checked = true;
                        break;
                    case RADIX.Base64:
                        rbMessageBase64.Checked = true;
                        break;
                    case RADIX.ASCII:
                        rbMessageAscii.Checked = true;
                        break;
                    case RADIX.Exception_FromFile:
                        rbMessageFromFile.Checked = true;
                        break;
                }
                if (showExceptionMessage)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbSignatureRadixChanged(object sender, EventArgs e)
        {
            try
            {
                if (mSignatureRadix == RADIX.Hex && sender == rbSignatureBase64)
                {
                    tbSignature.Text = Convert.ToBase64String(Hex.Decode(tbSignature.Text));
                    mSignatureRadix = RADIX.Base64;
                }
                else if (mSignatureRadix == RADIX.Base64 && sender == rbSignatureHex)
                {
                    tbSignature.Text = BitConverter.ToString(Convert.FromBase64String(tbSignature.Text)).Replace("-", "");
                    mSignatureRadix = RADIX.Hex;
                }
            }
            catch (Exception ex)
            {
                if (mSignatureRadix == RADIX.Hex)
                    rbSignatureHex.Checked = true;
                else // case RADIX.Base64:
                    rbSignatureBase64.Checked = true;

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static T[] RangeSubset<T>(T[] array, int startIndex, int length)
        {
            T[] subset = new T[length];
            Array.Copy(array, startIndex, subset, 0, length);
            return subset;
        }

        private static byte[] derEncodeSignature(byte[] signature)
        {
            byte[] r = RangeSubset(signature, 0, (signature.Length / 2));
            byte[] s = RangeSubset(signature, (signature.Length / 2), (signature.Length / 2));

            MemoryStream stream = new MemoryStream();
            DerOutputStream der = new DerOutputStream(stream);

            Asn1EncodableVector v = new Asn1EncodableVector();
            v.Add(new DerInteger(new BigInteger(1, r)));
            v.Add(new DerInteger(new BigInteger(1, s)));
            der.WriteObject(new DerSequence(v));

            return stream.ToArray();
        }

        const int INPUT_FILE_BUFFER_LEN = 8192;
        ISigner mSigner;
        byte[] mSignature;
        byte[] mMessage;

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Int64 temp = 0, percentSize;

            try
            {
                ((BackgroundWorker)sender).ReportProgress(0);

                using (Stream source = File.OpenRead(tbMessage.Text))
                {
                    percentSize = source.Length / 1000;
                    int bytesRead;
                    while ((bytesRead = source.Read(mMessage, 0, mMessage.Length)) > 0)
                    {
                        mSigner.BlockUpdate(mMessage, 0, bytesRead);
                        temp += bytesRead;
                        if (temp >= percentSize)
                        {
                            temp = 0;
                            // when using PerformStep() the percentProgress arg is redundant
                            ((BackgroundWorker)sender).ReportProgress(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbVerification.PerformStep();
        }

        void bgw_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                pbVerification.Value = pbVerification.Maximum;
                pbVerification.Value = pbVerification.Maximum - 1; // workaround for animation feature (aero theme)
                pbVerification.Value = pbVerification.Maximum;

                if (mSigner.VerifySignature(mSignature))
                    MessageBox.Show("Signature successfully verified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Bad signature", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                // Enable controls critical for execution:
                tabControl.Enabled = true;
            }
        }

        private void btnVerifySignature_Click(object sender, EventArgs e)
        {
            string signatureMechanism;
            AsymmetricKeyParameter key;

            try
            {
                if (tbMessage.Text.Trim().Equals(""))
                    throw new Exception("Signed message can't have a zero length.");
                if (tbSignature.Text.Trim().Equals(""))
                    throw new Exception("Signature can't have a zero length.");

                if (cbCipher.Text.Equals("RSA"))
                {
                    switch (cbDigest.Text)
                    {
                        case "SHA-1":
                            signatureMechanism = "SHA-1withRSA";
                            break;
                        case "SHA-224":
                            signatureMechanism = "SHA-224withRSA";
                            break;
                        case "SHA-256":
                            signatureMechanism = "SHA-256withRSA";
                            break;
                        case "SHA-384":
                            signatureMechanism = "SHA-384withRSA";
                            break;
                        case "SHA-512":
                            signatureMechanism = "SHA-512withRSA";
                            break;
                        default:
                            throw new Exception("Unknown hash algorithm");
                    }

                    key = new RsaKeyParameters(false, new BigInteger(1, Hex.Decode(tbRSAModulus.Text)), 
                        new BigInteger(1, Hex.Decode(tbRSAPubExp.Text)));
                }
                else if (cbCipher.Text.Equals("ECDSA"))
                {
                    switch (cbDigest.Text)
                    {
                        case "SHA-1":
                            signatureMechanism = "SHA-1withECDSA";
                            break;
                        case "SHA-224":
                            signatureMechanism = "SHA-224withECDSA";
                            break;
                        case "SHA-256":
                            signatureMechanism = "SHA-256withECDSA";
                            break;
                        case "SHA-384":
                            signatureMechanism = "SHA-384withECDSA";
                            break;
                        case "SHA-512":
                            signatureMechanism = "SHA-512withECDSA";
                            break;
                        default:
                            throw new Exception("Unknown digest algorithm");
                    }

                    X9ECParameters curve = SecNamedCurves.GetByName(cbECName.Text);
                    ECDomainParameters curveSpec = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());
                    key = new ECPublicKeyParameters("ECDSA", curve.Curve.DecodePoint(Hex.Decode(tbECPubKey.Text)), curveSpec);
                }
                else
                    throw new Exception("Unknown cipher algorithm");

                mSigner = SignerUtilities.GetSigner(signatureMechanism);
                mSigner.Init(false, key);

                switch (mMessageRadix) // from radix
                {
                    case RADIX.Hex:
                        mMessage = Hex.Decode(tbMessage.Text);
                        break;
                    case RADIX.Base64:
                        mMessage = Convert.FromBase64String(tbMessage.Text);
                        break;
                    case RADIX.ASCII:
                        mMessage = Encoding.ASCII.GetBytes(tbMessage.Text);
                        break;
                    case RADIX.Exception_FromFile:
                        mMessage = new byte[INPUT_FILE_BUFFER_LEN];
                        break;
                    default:
                        throw new Exception("Unknown input data radix");
                }

                if (cbCipher.Text.Equals("ECDSA"))
                {
                    // Have to be DER encoded before verification:
                    if (mSignatureRadix == RADIX.Hex)
                    {
                        mSignature = derEncodeSignature(Hex.Decode(tbSignature.Text));
                    }
                    else // mSignatureRadix == RADIX.Base64
                    {
                        mSignature = derEncodeSignature(Convert.FromBase64String(tbSignature.Text));
                    }
                }
                else
                {
                    if (mSignatureRadix == RADIX.Hex)
                    {
                        mSignature = Hex.Decode(tbSignature.Text);
                    }
                    else // mSignatureRadix == RADIX.Base64
                    {
                        mSignature = Convert.FromBase64String(tbSignature.Text);
                    }
                }

                pbVerification.Value = 0;
                Refresh();

                if (mMessageRadix == RADIX.Exception_FromFile)
                {
                    var bgw = new BackgroundWorker();
                    bgw.ProgressChanged += bgw_ProgressChanged;
                    bgw.DoWork += bgw_DoWork;
                    bgw.WorkerReportsProgress = true;
                    bgw.RunWorkerCompleted += bgw_WorkCompleted;
                    bgw.RunWorkerAsync();

                    // Disable controls critical for execution:
                    tabControl.Enabled = false;
                    return;
                }
                else
                    mSigner.BlockUpdate(mMessage, 0, mMessage.Length);

                bool result = mSigner.VerifySignature(mSignature);
                pbVerification.Value = pbVerification.Maximum;
                pbVerification.Value = pbVerification.Maximum - 1; // workaround for animation feature (aero theme)
                pbVerification.Value = pbVerification.Maximum;
                if (result)
                    MessageBox.Show("Signature successfully verified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Bad signature", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        const long MAX_INPUT_BIN_FILE = 65536;

        private void btnPlainLoadFromBin_Click(object sender, EventArgs e)
        {
            long file_len;

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                //dialog.InitialDirectory = @"C:\";
                dialog.Title = "Please select binary file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    file_len = new FileInfo(dialog.FileName).Length;

                    if (file_len > MAX_INPUT_BIN_FILE)
                    {
                        MessageBox.Show("Binary file is to large for this purpose.\r\nMaximum file size accepted here is 64 kB.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tbMessage.Text = "";
                    tbMessageRadixChanged(rbMessageHex, new EventArgs());
                    rbMessageHex.Checked = true;

                    tbMessage.Text = BitConverter.ToString(File.ReadAllBytes(dialog.FileName)).Replace("-", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignatureLoadFromBin_Click(object sender, EventArgs e)
        {
            long file_len;

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Signature binary files (*.sig)|*.sig|Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                //dialog.InitialDirectory = @"C:\";
                dialog.Title = "Please select binary file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    file_len = new FileInfo(dialog.FileName).Length;

                    if (file_len > MAX_INPUT_BIN_FILE)
                    {
                        MessageBox.Show("Binary file is to large for this purpose.\r\nMaximum file size accepted here is 64 kB.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    tbSignature.Text = "";
                    tbSignatureRadixChanged(rbSignatureHex, new EventArgs());
                    rbSignatureHex.Checked = true;

                    tbSignature.Text = BitConverter.ToString(File.ReadAllBytes(dialog.FileName)).Replace("-", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
