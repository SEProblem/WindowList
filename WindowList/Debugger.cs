using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WindowList {
    class Debugger {

        bool modified = true;
        DateTime lastWrite;
        string programsP;
        ArrayList tokens; 
    
        public Debugger() {
            programsP = Util.AssemblyDirectory + @"\programs.txt";
            tokens = new ArrayList();
        }
        public void processPrograms() {
            if (modified) {
                modified = !modified;
                lastWrite = File.GetLastWriteTime(programsP);
            } else {
                if (!(lastWrite.Equals(File.GetLastWriteTime(programsP)))) {
                    modified = !modified;
                }
            }
            for (int i = 0; i < tokens.Count; i++) {
                tokens.RemoveAt(0);
            }
            var lines = File.ReadLines(programsP);
            foreach (string line in lines) {
                if (line.Length == 0 || line.Substring(0, 2).Equals("//"))
                    continue;
                else if (line.First().Equals('~')) {
                    tokens.Add(line.Substring(1));
                    continue;
                }
                string[] tokenArray = ((string)line).Split(new char[] { ' ' });
                foreach (string token in tokenArray) {
                    tokens.Add(token);
                }
            }
        }
        public bool checkPrograms(string title) {
            foreach (string token in tokens) {
                string tok = token;
                string tit = title; // oof
                if (!token.Equals("") && token.First() == '!') {
                    tok = tok.Substring(1);
                }
                else {
                    tok = token.ToLower();
                    tit = title.ToLower();
                }
                if (tit.Contains(tok) && !token.Equals(""))
                    return true;
            }
            return false;
        }
    }
}
