using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Constants // Sabitler
{
    public class Messages
    {
        public static class Brand
        {
            public static string NotExists = "BRAND_NOT_EXISTS";
            public static string AlreadyExists = "BRAND_ALREADY_EXISTS";
        }

        public static class Car
        {
            public static string NotExists = "CAR_NOT_EXISTS";
            public static string AlreadyExists = "CAR_ALREADY_EXISTS";
            public static string InvalidPlate = "PLATE_IS_NOT_VALID";
            public static string CarNotAvailable = "CAR_NOT_AVAILABLE";
        }
    }
}
