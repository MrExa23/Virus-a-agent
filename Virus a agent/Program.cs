using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        List<Tuple<int, int>> links = new List<Tuple<int, int>>();
        List<int> exit = new List<int>();

        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            links.Add(new Tuple<int, int>(N1, N2));

        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            exit.Add(EI);
        }

        List<Tuple<int, int>> agentLinks = new List<Tuple<int, int>>();
        
        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // Example: 0 1 are the indices of the nodes you wish to sever the link between

            Console.WriteLine(FindingExit());

            string FindingExit()
            {
                int n1=0;
                int n2=0;
                List<int> agentNodes = new List<int>();
                agentNodes.Add(SI);
                bool hledani = true;
                bool b = false;
                int a = 0;

                while (hledani)
                {
                    
                    for (int i = 0; i < L; i++)
                    {
                        if (links[i].Item1 == agentNodes[a] || links[i].Item2 == agentNodes[a])
                        {
                            if (links[i].Item1 == agentNodes[a])
                            {
                                if (!agentNodes.Contains(links[i].Item2))
                                {
                                    agentNodes.Add(links[i].Item2);
                                }
                            }
                            else
                            {
                                if (!agentNodes.Contains(links[i].Item1))
                                {
                                    agentNodes.Add(links[i].Item1);
                                }
                            }
                            agentLinks.Add(links[i]);

                            for (int j = 0; j < E; j++)
                            {     
                                b = false;
                                if (agentNodes.Contains(exit[j]))
                                {
                                    hledani = false;

                                    n1 = links[i].Item1;
                                    n2 = links[i].Item2;
                                    b = true;
                                    links.RemoveAt(i);
                                    L--;
                                    break;
                                }
                            }
                        }
                        
                        if (b) { break; }
                    }
                    //agentNodes.RemoveAt(0);
                    a++;
                }

                return $"{n1} {n2}";
            }
            

            
        }

        
    }
    
}

