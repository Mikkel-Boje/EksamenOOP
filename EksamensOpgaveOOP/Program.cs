

namespace Stregsystemet {
    class Program {
        static void Main(string[] args){
            IStregsystem system = new Stregsystem();
            IStregsystemUI cli = new StregsystemetCLI(system);
            StregsystemController controller = new StregsystemController(system, cli);
            cli.Start();
        }
    }
}
