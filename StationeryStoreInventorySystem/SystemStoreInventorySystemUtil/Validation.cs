using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemStoreInventorySystemUtil
{
    public class Validation
    {
        public enum VALIDATE_OPTION
        {
            USERNAME,
            USERNAME_FORMAT,
            PASSWORD,
            ZIP,
            EMAIL,
            ADDRESS,
            POSTAL_CODE,
            MOBILE_PHONE,
            CREDIT_CARD_NO,
            CREDIT_CARD_CVV,
            PRICE,
            QUANTITY
        }

        public static bool validate(VALIDATE_OPTION option, object obj)
        {
            bool isValidate = true;

            try
            {
                switch (option)
                {
                    case VALIDATE_OPTION.USERNAME: // Username should have at least 5 characters and maximum 50 characters
                        isValidate = obj.ToString().Trim().Length > 4 && obj.ToString().Length < 51 ? true : false;
                        break;
                    case VALIDATE_OPTION.USERNAME_FORMAT:

                        string usernamePattern = @"^[a-z -']+$";
                        System.Text.RegularExpressions.Regex username = new System.Text.RegularExpressions.Regex(usernamePattern);

                        isValidate = username.IsMatch(obj.ToString());
                        break;
                    case VALIDATE_OPTION.ZIP:

                        string zipCode = @"^\d{6}$";
                        System.Text.RegularExpressions.Regex zip = new System.Text.RegularExpressions.Regex(zipCode);

                        isValidate = zip.IsMatch(obj.ToString());
                        break;
                    case VALIDATE_OPTION.PASSWORD: // Username should have at least 5 characters and maximum 50 characters
                        isValidate = obj.ToString().Trim().Length > 4 && obj.ToString().Length < 51 ? true : false;
                        break;
                    case VALIDATE_OPTION.EMAIL:
                        string emailPattern = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                    + @"[a-zA-Z]{2,}))$";
                        System.Text.RegularExpressions.Regex reStrict = new System.Text.RegularExpressions.Regex(emailPattern);

                        isValidate = reStrict.IsMatch(obj.ToString());
                        break;
                    case VALIDATE_OPTION.ADDRESS:
                        break;
                    case VALIDATE_OPTION.POSTAL_CODE:
                        isValidate = obj.ToString().Trim().Length == 6 ? true : false;
                        break;
                    case VALIDATE_OPTION.MOBILE_PHONE:
                        isValidate = obj.ToString().Trim().Length == 8 || (obj.ToString().IndexOf("+") == 0 && obj.ToString().Trim().Length == 11) ? true : false;
                        break;
                    case VALIDATE_OPTION.CREDIT_CARD_NO:
                        isValidate = obj.ToString().Replace(" ", "").Trim().Length == 16 ? true : false;
                        break;
                    case VALIDATE_OPTION.CREDIT_CARD_CVV:
                        isValidate = obj.ToString().Trim().Length == 3 ? true : false;
                        break;
                    case VALIDATE_OPTION.PRICE:
                    case VALIDATE_OPTION.QUANTITY:
                        isValidate = Converter.objToInt(obj) > 0 ? true : false;
                        break;
                }
            }
            catch (Exception e)
            {
                isValidate = false;
            }

            return isValidate;
        }

        //Defines the set of characters that will be checked.
        //You can add to this list, or remove items from this list, as appropriate for your site
        private static string[] blackList = {"--",";--",";","/*","*/","@@","@",
                                            "char","nchar","varchar","nvarchar",
                                            "alter","begin","cast","create","cursor","declare","delete","drop","end","exec","execute",
                                            "fetch","insert","kill","open",
                                            "select", "sys","sysobjects","syscolumns",
                                            "table","update"};

        //The utility method that performs the blacklist comparisons
        public static string CheckInput(string parameter)
        {
            for (int i = 0; i < blackList.Length; i++)
            {
                if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    //
                    //Handle the discovery of suspicious Sql characters here
                    //
                    //HttpContext.Current.Response.Redirect("~/Error.aspx");  //generic error page on your site
                    parameter.Replace(blackList[i], "");
                }
            }

            return parameter;
        }
    }
}
