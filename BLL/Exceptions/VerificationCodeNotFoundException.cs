namespace BLL.Exceptions
{
    public class VerificationCodeNotFoundException : Exception
    {
        public VerificationCodeNotFoundException() : base() { }
        public VerificationCodeNotFoundException(string code) : base($"Verification code '{code}' not found.") { }
    }
}
