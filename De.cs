using System;

namespace JeuDu421
{
    public class De
    {
        public int NbFaces;
        private Random random = new Random();
        public int Face { get; protected set; }

        public De(int nbFaces, int face)
        {
            NbFaces = nbFaces;
            Face = face;

        }
        
        public virtual int Lancer()
        {
            Face = random.Next(0, NbFaces) + 1;
            return Face;
        }

        public override string ToString()
        {
            string toString = String.Format($"| {Face} | ");
            return toString;
        }

    }
    
    
}
