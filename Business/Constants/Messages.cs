using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string NotBeExist = "Not Be Exist";
        public static string AlreadyExist = "Already Exist";
        public static string AddData = "Add Data";
        public static string DeleteData = "Delete Data";
        public static string UpdateData = "Update Data";
        public static string ListData = "List Data";
        public static string GetData = "Get Data";
        public static string MustContainAtMinTwoChar = "Must Contain At Minimum Two Char";
        public static string PleaseEnterAValidNationalyIdNumber = "Please Enter A Valid Nationaly Id Number";
        public static string MustContainAtMaxTenChar = "Must Contain At Maximum Ten Char";
        public static string MustBeGreaterThanZero = "Must Be Greater Than Zero";
        public static string CarAtCustomer = "Car At Customer";
        internal static string UserRegistered;
        internal static string UserNotFound;
        internal static string PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
    }
}
