// Zachariah Kendall
// CSCD 300
// Lab 4: Infix to postfix.
// Write a calculator that can convert from infix to post fix,
//  and evaltuate the expession.

public class InFixPostFixTester
{
    public static void main(String[] args)
    {
	inFixPostFix calculator = new inFixPostFix();
	calculator.loadFile();
	calculator.in2PostFix();

    }

}
