using System;

class OTPGenerator
{
    // method to generate 6-digit OTP using Math.Random()
    public static int GenerateOTP()
    {
        // Math.Random() gives value between 0.0 to 1.0
        int otp = (int)(Math.Random() * 900000) + 100000;
        return otp;
    }

    // method to check if all OTPs are unique
    public static bool AreOTPsUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void Main()
    {
        int[] otpArray = new int[10];

        // generate OTPs 10 times
        for (int i = 0; i < otpArray.Length; i++)
        {
            otpArray[i] = GenerateOTP();
        }

        // display OTPs
        Console.WriteLine("Generated OTPs:");
        for (int i = 0; i < otpArray.Length; i++)
        {
            Console.WriteLine("OTP " + (i + 1) + ": " + otpArray[i]);
        }

        // check uniqueness
        bool isUnique = AreOTPsUnique(otpArray);

        Console.WriteLine("\nAre all OTPs unique? " + isUnique);
    }
}
