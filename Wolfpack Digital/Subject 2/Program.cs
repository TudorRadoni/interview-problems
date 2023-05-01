namespace Subject_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
        }
    }

    abstract class Student
    {
        int ID;
        string Name;

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public abstract double CalculateTuition(int numberOfCredits);
    }

    class InStateStudent : Student
    {
        double SemesterFee;

        public InStateStudent(int id, string name, double semesterFee) : base(id, name)
        {
            SemesterFee = semesterFee;
        }

        public override double CalculateTuition(int numberOfCredits)
        {
            return SemesterFee;
        }
    }

    class OutOfStateStudent : Student
    {
        double SemesterFee;
        int PerCreditFee;

        public OutOfStateStudent(int id, string name, double semesterFee, int perCreditFee) : base(id, name)
        {
            SemesterFee = semesterFee;
            PerCreditFee = perCreditFee;
        }

        public override double CalculateTuition(int numberOfCredits)
        {
            return SemesterFee + (PerCreditFee * numberOfCredits);
        }
    }
}
