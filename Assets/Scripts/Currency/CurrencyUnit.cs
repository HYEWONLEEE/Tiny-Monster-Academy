using UnityEngine;
//재화 단위를 변환하는 클래스
public static class CurrencyUnit 
{
    //사용할 단위 배열 
    static readonly string[] currencyUnits = new string[]
    {
        "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
        "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF",
        "AG", "AH", "AI", "AJ","AK","AL","AM","AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU",
        "AV", "AW", "AX", "AY", "AZ"
    };

    public static string ToCurrencyString(this double number)
    {
        string zero = "0";

        if (-1.0d < number && number <=1.0d)
        {
            return zero;
        }

        if (double.IsInfinity(number))
        {
            return "Infinity";
        }


        //부호 출력 문자열
        string significant = (number < 0) ? "-" : string.Empty; 

        string showNumber = string.Empty;

        string unityString = string.Empty;

        //지수 표현식으로 변경하기
        string[] partsSplit = number.ToString("E").Split('+');
        //예외
        if(partsSplit.Length <2)
        {
            return zero;
        }
        //지수 (자릿수 표현)
        if (!int.TryParse(partsSplit[1], out int exponent))
        {
            Debug.LogWarningFormat("Failed - ToCurrencyString({0}) : partSplit[1] = {1}", number, partsSplit[1]);
            return zero;
        }

        //묶은 문자열 인덱스
        int quotient = exponent / 3;
        //정수부 자릿수 계산
        int remainder = exponent % 3;

        if( exponent < 3 ) //1A미만은 그냥 표현
        {
            showNumber = System.Math.Truncate(number).ToString();

        }

        else
        {
            var temp = double.Parse(partsSplit[0].Replace("E", "")) * System.Math.Pow(10, remainder);
            showNumber = temp.ToString("F").Replace(".00", "");
        }

        unityString = currencyUnits[quotient];

        return string.Format("{0}{1}{2}", significant, showNumber, unityString);
    }

}
