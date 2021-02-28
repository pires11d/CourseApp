using System;
namespace Course.Entities
{
    public class Person
    {
        public Person()
        {            
        }

        public Person(string name, int age, double height, char gender = 'X')
        {
            Name = name;
            Age = age;
            Height = height;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        private char _gender;
        public char Gender
        {
            get { return _gender; }
            set { _gender = char.ToUpper(value); }
        }
                
        public string GetArticle()
        {
            switch (Gender)
            {
                case 'M':
                    return "O";
                case 'F':
                    return "A";
                default:
                    return "X";
            }
        }

        public string ToString(int printType)
        {
            switch (printType)
            {
                case 1:
                    return Interpolation();
                case 2:
                    return Concatenation();
                case 3:
                    return Placeholding();
                default:
                    return "";
            }
        }

        private string Interpolation()
        {
            return $"{this.GetArticle()} {this.Name} tem {this.Age} anos e {this.Height.ToString("F2")} de altura";
        }

        private string Concatenation()
        {
            return this.GetArticle() + " " + this.Name + " tem " + this.Age + " anos e " + this.Height.ToString("F2") + " de altura";
        }

        private string Placeholding()
        {
            return String.Format("{0} {1} tem {2} anos e {3:F2} de altura", this.GetArticle(), this.Name, this.Age, this.Height);
        }
    }
}