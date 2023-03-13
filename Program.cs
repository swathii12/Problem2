using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> Credentials = new Dictionary<string, string>();
            Dictionary<string, string> Bitmask = new Dictionary<string, string>();

            

            using(StreamReader reader=new StreamReader("C:\\Users\\sbp\\source\\repos\\Problem2\\CredentialImportFile.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string credential=parts[0];
                    string tenantId=parts[1];
                    Credentials.Add(credential, tenantId);
                }
            }

   

            using (StreamReader reader=new StreamReader("C:\\Users\\sbp\\source\\repos\\Problem2\\BitmaskFile.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string tenant = parts[0];
                    string bitmask=parts[1];
                    Bitmask.Add(tenant, bitmask);
                }
            }

            Dictionary<string, string> Output = new Dictionary<string, string>();

            foreach(KeyValuePair<string, string> credential in Credentials)
            {
                string CredentialValue=credential.Key;
                string TenantIdValue = credential.Value;

                int CredentialvaluetoInt=Convert.ToInt32(CredentialValue);

                int bitmask = Convert.ToInt32( Bitmask[TenantIdValue]);

                if (!Bitmask.ContainsKey(TenantIdValue))
                {
                    throw new BitMaskConversionException("Could not convert for tenantId: "+TenantIdValue);
                }

                string Conversion =Convert.ToString(CredentialvaluetoInt ^ bitmask);

                Output.Add(CredentialValue, Conversion);
            }

            using (StreamWriter writer = new StreamWriter("C:\\Users\\sbp\\source\\repos\\Problem2\\OutputFile.txt"))
            {
                writer.WriteLine("Credential, After Conversion");

                foreach(KeyValuePair<string, string> converted in Output)
                {
                    string Credential=converted.Key;
                    string ConvertedCredential = converted.Value;

                    writer.WriteLine($"{Credential},{ConvertedCredential}");
                }
            }
        }
    }
}