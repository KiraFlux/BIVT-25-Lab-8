namespace Lab8.Blue
{
    public class Task1
    {
        public class Response(string name)
        {
            readonly string name = name;
            protected int votes = 0;

            public string Name => name;
            public int Votes
            {
                get => votes;
                set
                {
                    votes = Votes;
                }
            }

            virtual public int CountVotes(Response[] responses)
            {
                this.votes = responses.Count(Same);

                for (int i = 0; i < responses.Length; i += 1)
                {
                    ref var r = ref responses[i];
                    if (Same(r)) { r.votes = this.votes; }
                }

                return this.votes;
            }

            virtual public void Print() => Console.WriteLine(this.ToString());

            bool Same(Response other) => this.name == other.name;

            override public string ToString() =>
                $"Response{{name: \"{name}\", votes: {votes}}}";
        }

        public class HumanResponse(string n, string surname) : Response(n)
        {
            readonly string surname = surname;
            public string Surname => surname;

            bool Same(Response other) => this.Name == other.Name && this.surname == ((HumanResponse)other).Surname;

            override public int CountVotes(Response[] responses)
            {
                this.votes = responses.Count(Same);

                for (int i = 0; i < responses.Length; i += 1)
                {
                    ref var r = ref responses[i];
                    if (Same(r)) { r.Votes = this.votes; }
                }

                return this.votes;
            }

            override public void Print() => Console.WriteLine(this.ToString());

            override public string ToString() =>
                $"Response{{name: \"{Name}\", surname: \"{Surname}\", votes: {votes}}}";

        }
    }
}