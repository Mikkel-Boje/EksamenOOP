

namespace Stregsystemet {
    class Program {
        static void Main(string[] args){
            IStregsystem system = new Stregsystem();
            IStregsystemUI cli = new StregsystemetCLI(system);
            cli.Start();
        }
    }
}
