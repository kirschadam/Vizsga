namespace WPF_Vizsga
{
    public class Teglalap
    {
        public int A { get; set; }
        public int B { get; set; }

        public Teglalap(string sor)
        {
            string[] parts = sor.Split('\t');

            A = int.Parse(parts[0]);
            B = int.Parse(parts[1]);
        }

        public Teglalap(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}
