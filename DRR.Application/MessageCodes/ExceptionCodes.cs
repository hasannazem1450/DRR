namespace DRR.Application.MessageCodes;

public class ExceptionCodes
{
    public class SystemMessage
    {
        public static ApplicationExceptionMessageCode SystemErrorCanNotFound = 20;
        public static ApplicationExceptionMessageCode SystemErrorCodeIsDuplicate = 21;
        public static ApplicationExceptionMessageCode SystemErrorMessageIsEmpty = 22;
    }

    public class Identity
    {
        public static ApplicationExceptionMessageCode IdentityError = 10;
        public static ApplicationExceptionMessageCode UsernameOrPasswordIncorrect = 11;
        public static ApplicationExceptionMessageCode UserNameOrPhoneNumberIsNullOrEmpty = 12;
        public static ApplicationExceptionMessageCode UserNotExist = 13;
        public static ApplicationExceptionMessageCode ClientHaveNoToken = 14;
        public static ApplicationExceptionMessageCode UserNameOrPhoneNumberIsNotValid = 15;
        public static ApplicationExceptionMessageCode ActivatingCodeNotSended = 16;
        public static ApplicationExceptionMessageCode ActivatingCodeIsInvalid = 16;
    }

    public class SmeProfile
    {
        public static ApplicationExceptionMessageCode SmeRaterIsNotExist = 30;
        public static ApplicationExceptionMessageCode SmeProfileIsNotExist = 31;
    }

    public class EventInfo
    {
        public static ApplicationExceptionMessageCode DateRangeIsInvalid = 40;
    }
    public class Product
    {
        public static ApplicationExceptionMessageCode ProductNotFound = 50;
    }
    public class DRRFile
    {
        public static ApplicationExceptionMessageCode DRRFileNotFound = 60;
    }
    public class SiteMessenger
    {
        public static ApplicationExceptionMessageCode MessageReciversIsEmpty = 70;
    }
}