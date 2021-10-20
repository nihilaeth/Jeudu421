using System;

namespace JeuDu421
{
    public class DeTruque : De
    {
        private Random random = new Random();
        
        public DeTruque(int nbFaces, int face) : base(nbFaces, face)
        {
            
        }
        
        public override int Lancer()
        {
            int jet = random.Next(0, 12);
            if (jet > 6)
            {
                return Face = 6;
            } else if (jet == 5 || jet == 6)
            {
                return Face = 5;
            }
            else
            {
                return Face = jet + 1;
            }
        }
    }
}