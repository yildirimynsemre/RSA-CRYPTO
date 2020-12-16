using System;
using System.Security.Cryptography;
using System.Text;

namespace RSA005
{
    class Program
    {
        //static string publicKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        //static string privateKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";

        static string publicKey = "<RSAKeyValue><Modulus>69KyCU2q723OaZIaB8YRpqxRkKEtpuipU8KOkblqUymxlMWrmYNN+yJuQ80vSVrH46fuehodD1fMRKYRq8y4mfa24a4ZzlHxvbwTBySy36T8Akq2wfqrBawC2OY2oh5W7swqkpi81m8W/R0p0sBmM05LSwfCsCkw/2FlJH/a9zyH9HBwWSwsBOPfbNhzYCSOycOZbUkfmD9QAA+td3GZ2eVccv7UMrgP5wta0PpmaCP0oD7Ri4FE+zQQBMmyJltnA7HgS3yxJnmRY6/BrlGMhlitkESo06v1nAgD1ILCPLZxvBA57bd3lRC2KzeYHD+k3+e8O6tgnHtCjtKyX+6gwQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        static string privateKey = "<RSAKeyValue><Modulus>69KyCU2q723OaZIaB8YRpqxRkKEtpuipU8KOkblqUymxlMWrmYNN+yJuQ80vSVrH46fuehodD1fMRKYRq8y4mfa24a4ZzlHxvbwTBySy36T8Akq2wfqrBawC2OY2oh5W7swqkpi81m8W/R0p0sBmM05LSwfCsCkw/2FlJH/a9zyH9HBwWSwsBOPfbNhzYCSOycOZbUkfmD9QAA+td3GZ2eVccv7UMrgP5wta0PpmaCP0oD7Ri4FE+zQQBMmyJltnA7HgS3yxJnmRY6/BrlGMhlitkESo06v1nAgD1ILCPLZxvBA57bd3lRC2KzeYHD+k3+e8O6tgnHtCjtKyX+6gwQ==</Modulus><Exponent>AQAB</Exponent><P>86IzhvfuFWMUAEChnHW7FyhNCgyANJryAClaQNUS1j4nV3Nu5T3yPjEDX/wyN3ael75dzbv3VjHxeDbBw3Iy6CVk151sVJlvCwO0iKHbK+UQqTzkDkDjVBelqLJJat2xEpGL2hOhdvQ2ylUEpQuCjkSDJCVN2GtWzLljAHGGda8=</P><Q>98sAvFE8YDYwbboIieLJah4GM+wrvFHXHgeLh5p+Jr//zJk5UgTqi/HxItRwF52HDMMkWpfwy5jFhm+BS1IOKCPVM6vJputDAFF4rezbuy7dXQLZFlXTHkpUYTCitTRyHhaL0Pp66V0TRfjq5DjXMT2MuqqZD6CCHECpr/74XI8=</Q><DP>OM6cNx8+K0xz0G9Bf4rP+eFSvUIW7q0mOjVqLu2/u6a4Y6Ktu9QK1Md24v2Z8+a7qeQgWSU30ahJhl82JM1O42Q8tC2nob447xeJE8axpPV/QgbJoi0tFGGDJeeUSM+yRwMa2dlz75mX4Oub7qPVaDi/X0E3envkvE2JsQPHd08=</DP><DQ>WaOaVIWerb9srYUK6bac3kKWQ9o/yBRjGX3pP9jnoeT7CGy1i7IzlwSjEtJ+6kwWOsutLwigF0bgzc0wnKrGbEbqLZMLk9KvnkHawjBZHNHLSoZpOec6RE7nT3FkquCaF8BYO/Ug2aLOAhYWAxF851c4vZ5RWJHb/5R0zjISbok=</DQ><InverseQ>YqUgzsetlraJw/7JB5zzjixZKfo9EPMgspBOAt8pZv/eGfy/UL1l4KqlaBQmB1a4frNsaWggVMGq+XIYBe8mfG5zZtOTEa5WW3ZIlb8rRkF3HKmcAJWIGgZD6ByLqLMM69px6dzAL+lBzikNoE5W6JVKcSs8nUunB1azuj8T7gA=</InverseQ><D>F7SqaP0BvefP5BTnwPhMNfEEkgFh0XF59A2Ov19gLNP4Ifhs85WbdS9U3kP2CO2zQlNTSbruSOiOhCgdhqOhuvhuEemqdm8OWgBZ+VHbGVhAbQqNrJpCLuPHtX4O5+Uc4AxuCyaHdRbdvLv9xE3K+EValERHceXyIvnrbOvdWxTtPzrxXLaPW+o/QTceTzHrqdbVmrdiRaIwB58ygsQ1gHFywfba99GXBcs2E3LHhY3/B9f3OruOKgWohVQLgIUdSslZBE2PXJ/t/e9phNfK4eGOyC2XQXl8o41cHskBrD35QMSvuBKjGBEUA1aHB3T4xaI5g+fQJtnrH2V4NFWM8Q==</D></RSAKeyValue>";



        public static string Encryption(string strText)
        {
            

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(publicKey.ToString());

                    var encryptedData = rsa.Encrypt(testData, true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decryption(string strText)
        {
            

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    var base64Encrypted = strText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }




        static void Main(string[] args)
        {
            string a = "asfg";
            var b = Encryption(a);
            var c = Decryption(b);
            Console.WriteLine("Hello World!");
        }
    }
}
