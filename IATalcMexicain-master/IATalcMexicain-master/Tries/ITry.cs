using System;
using System.Collections.Generic;
using System.Text;

namespace ClientTM.Tries
{
    /// <summary>
    /// Interface générale d'un challenge
    /// </summary>
    public interface ITry
    {
        /// <summary>
        /// Lancer le challenge
        /// </summary>
        public void Executer();
    }
}
