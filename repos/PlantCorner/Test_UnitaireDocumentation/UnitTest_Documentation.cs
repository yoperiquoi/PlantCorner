using System;
using System.Linq;
using Xunit;
using Modèle.Documentation;

namespace Test_UnitaireDocumentation
{
    /// <summary>
    ///Test simpliste des tests unitaires pour la documentation
    /// </summary>
    public class UnitTest_Documentation
    {
        //Test pour le chargement des plante à partir de la persistance XML
        [Fact]
        public void ChargementDonnée()
        {
            Doc Doc = new Doc();

            Assert.Equal(12, Doc.LesPlantes.Count);
            Assert.Equal(Doc.LesPlantes, Doc.LesPlantesFixé);
        }

        //Test pour la modification d'une plante
        [Fact]
        public void ModificationPlante()
        {
            Doc Doc = new Doc();

            MaPlante PlanteRéférence = new MaPlante(Doc.MesPlantes.ElementAtOrDefault(0));

            MaPlante mp1 = new MaPlante("Ceci est un test de modification ", "Rose bleue", "Rosa", "../Img/LogoPC.png",
              "La rose est la fleur des rosiers, arbustes du genre Rosa. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
              Couleurs.Rouge, Saisons.Ete, "Instruction");
            MaPlante mp;

            mp = Doc.ModifierMaPlante(Doc.MesPlantes.ElementAtOrDefault(0), mp1);

            Assert.NotEqual(PlanteRéférence, mp);
        }

        //Test pour l'ajout d'une plante à la liste personnelle avec une note par défaut
        [Fact]
        public void AjouterMaPlante()
        {
            Doc Doc = new Doc();

            int NombreDePlantePersonnelleInitial = Doc.MesPlantes.Count;

            Plante p = new Plante("Rose", "Rosa", "../Img/LogoPC.png",
                "La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
                Couleurs.Rouge, Saisons.Ete, "Ceci est les instruction d'entretient de la plante");
            MaPlante mp = new MaPlante("ceci est la description de base", p);
            Doc.AjouterMaPlante(mp);

            NombreDePlantePersonnelleInitial++;

            Assert.Equal(NombreDePlantePersonnelleInitial, Doc.NombreDePlantePersonnelle);
        }

        //Test de suppression d'un plante de la liste personelle
        [Fact]
        public void SupprMaPlante()
        {
            Doc Doc = new Doc();

            int NombreDePlantePersonnelleInitial = Doc.MesPlantes.Count;

            MaPlante mp = new MaPlante("Ceci est une description", "Rose", "Rosa", "../Img/LogoPC.png",
                "La rose est la fleur des rosiers, arbustes du genre Rosa et de la famille des Rosaceae. La rose des jardins se caractérise avant tout par la multiplication de ses pétales imbriqués qui lui donne sa forme caractéristique.",
                Couleurs.Rouge, Saisons.Ete, "Ceci est les instruction d'entretient de la plante");
            Doc.SupprMaPlante(mp);

            NombreDePlantePersonnelleInitial--;

            Assert.Equal(NombreDePlantePersonnelleInitial, Doc.NombreDePlantePersonnelle);
        }
    }
}
