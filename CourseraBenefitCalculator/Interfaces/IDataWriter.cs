namespace CourseraBenefitCalculator.Interfaces
{
    interface IDataWriter
    {
        public void Write(IList<string> lines, string Path);
    }
}
