namespace BLL.Models
{
    public class UserVerification
    {
        public Guid Guid { get; set; }
        public string VerificationCode { get; set; }

        public UserVerification(Guid guid, string verificationCode)
        {
            Guid = guid;
            VerificationCode = verificationCode;
        }
    }
}
