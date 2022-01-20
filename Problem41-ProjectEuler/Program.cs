
List<double> allPrimes = new();
List<double> possiblePanPrimes = new();
allPrimes.Add(2);

double maxPanPrime = 0;

string pand7Digit = "7654321";

GetPer(pand7Digit.ToCharArray());
var sortedList = possiblePanPrimes.OrderByDescending(d => d);

foreach(double panprime in sortedList)
{
    bool checkedIsPrime = true;
    for(double i = 3; i <= panprime; i += 2)
    {
        bool isPrime = true;
        foreach(double prime in allPrimes)
        {
            if (prime >= i)
                break;
            if(i%prime == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime && panprime % i == 0)
        {
            checkedIsPrime = false;
            break;
        }
        if(isPrime && !allPrimes.Contains(i))
            allPrimes.Add(i);
        if (i > panprime / 2)
            break;
    }
    if (checkedIsPrime)
    {
        maxPanPrime = panprime;
        break;
    }
}

 Console.WriteLine("The largest n-digit pandigital prime that exists is: " + maxPanPrime);

void Swap(ref char a, ref char b)
{
    if (a == b) return;

    var temp = a;
    a = b;
    b = temp;
}

void GetPer(char[] list)
{
    int x = list.Length - 1;
    GetPer2(list, 0, x);
}

void GetPer2(char[] list, int k, int m)
{
    if (k == m)
    {
        if(list[list.Length - 1] == '1' ||
            list[list.Length - 1] == '3' ||
            list[list.Length - 1] == '7' ||
            list[list.Length - 1] == '9')
            possiblePanPrimes.Add(Convert.ToDouble(new string(list)));
    }
    else
        for (int i = k; i <= m; i++)
        {
            Swap(ref list[k], ref list[i]);
            GetPer2(list, k + 1, m);
            Swap(ref list[k], ref list[i]);
        }
}