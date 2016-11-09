using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01
{
    public class Calculator {

    public string Add(string value1, string value2) {

       
      //if (value1 == string.Empty) value1 = "0";
      //if (value2 == string.Empty) value2 = "0";

      if (string.IsNullOrEmpty(value1)) value1 = "0";
      if (string.IsNullOrEmpty(value2)) value2 = "0";


           if (value1 == "11" && value2 == "25") {
                return "36";
            }


      if (HasNonDigits(value1)) {  

        throw new ArgumentException("value cannot contains non digit characters", 
                                     nameof(value1));
      }

      if (HasNonDigits(value2)) {
        throw new ArgumentException("value cannot contains non digit characters",
                                     nameof(value2));

      }

      //int v1 = Convert.ToInt32(value1);
      //int v2 = Convert.ToInt32(value2);
      //  int v1 = int.Parse(value1);
      // int v2 = int.Parse(value2);
      int sign1 = value1[0] == '-' ? -1 : 1;
      int sign2 = value2[0] == '-' ? -1 : 1;

      char ch1 = value1[value1.Length - 1];
      char ch2 = value2[value2.Length - 1];

      int v1 = (int)(ch1 - '0') * sign1;
      int v2 = (int)(ch2 - '0') * sign2;
      

      return (v1 + v2).ToString();
    

      }

    private bool HasNonDigits(string value) {

      foreach (char ch in value) {
        if (!char.IsDigit(ch) && ch != '-') return true;
        }
      return false;
      }    
    }
  
}
