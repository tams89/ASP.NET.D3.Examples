using System.Collections.Generic;

namespace ASP.NET.D3.Examples.Model.Json
{
    public class Models
    {
        public class Reference
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
        }

        public class Company : Reference
        {
            public Reference Parent { get; set; }
            public IEnumerable<Subsidiary> Children { get; set; }
        }

        public class Subsidiary : Reference
        {
            public Reference Parent { get; set; }
            public IEnumerable<Department> Children { get; set; }
        }

        public class Department : Reference
        {
            public Reference Parent { get; set; }
        }
    }
}