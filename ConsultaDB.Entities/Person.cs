namespace ConsultaDB.Entities
{
    public class Person
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _title;

        public int id {
            get { return _id; }
            set { _id = value; }
        }
        public string firstName {
            get {return _firstName; }
            set {_firstName = value ?? ""; }
        }
        public string lastName {
            get {return _lastName; }
            set {_lastName = value ?? ""; }
        }
        public string middleName {
            get {return _middleName; }
            set {_middleName = value ?? ""; }
        }
        public string title {
            get {return _title; }
            set {_title = value ?? ""; }
        }

        public Person(int id, string nombre, string apellido, string segundoNombre, string titulo)
        {
            this.id = id;
            firstName = nombre;
            lastName = apellido;
            middleName = segundoNombre;
            title = titulo;
        }

        public Person()
        {
            firstName = "";
            lastName = "";
            middleName = "";
            title = "";
        }

        public override bool Equals(object persona)
        {
            var persona2 = (Person)persona;
            return id.Equals(persona2.id) 
                && firstName.Equals(persona2.firstName) 
                && lastName.Equals(persona2.lastName);
        }
    }
}
