using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace CST.Selector
{
    public partial class SelectorEntities : ObjectContext
    {
        public IEnumerable<MakeModel> PubMakes()
        {
            return (from c in SelectorPubCars
                   select new MakeModel
                   {
                       MakeCD = c.MakeCD,
                       MakeDescription = c.MakeDescription
                   }).Distinct().OrderBy(c => c.MakeDescription);
        }

        public IEnumerable<YearModel> PubYears(string makeCD)
        {
            return (from c in SelectorPubCars
                    where c.MakeCD == makeCD
                    select new YearModel
                    {
                        MakeCD = c.MakeCD,
                        MakeDescription = c.MakeDescription,
                        YearCD = c.YearCD
                    }).Distinct().OrderByDescending(c => c.YearCD);
           
        }

        public IEnumerable<ModelModel> PubModels(string makeCD, decimal yearCD)
        {
            return (from c in SelectorPubCars
                    where c.MakeCD == makeCD && c.YearCD == yearCD
                    select new ModelModel
                    {
                        MakeCD = c.MakeCD,
                        MakeDescription = c.MakeDescription,
                        YearCD = c.YearCD,
                        ModelCD = c.ModelCD,
                        ModelDescription = c.ModelDescription
                    }).Distinct().OrderBy(c => c.ModelDescription);
        }

        public IEnumerable<CarModel> PubCars(string makeCD, decimal yearCD, string modelCD)
        {
            return (from c in SelectorPubCars
                    where c.MakeCD == makeCD && c.YearCD == yearCD && c.ModelCD == modelCD
                    select new CarModel
                    {
                        MakeCD = c.MakeCD,
                        MakeDescription = c.MakeDescription,
                        YearCD = c.YearCD,
                        ModelCD = c.ModelCD,
                        ModelDescription = c.ModelDescription,
                        BodyCD = c.BodyCD,
                        BodyDescription = c.BodyDescription,
                        CarCD = c.CarCD
                    }).Distinct().OrderBy(c => c.BodyDescription);
        }

        public IEnumerable<CatalogModel> PubCatalogs(string carCD)
        {
            return (from c in SelectorPubCars
                    where c.CarCD == carCD
                    select new CatalogModel
                    {
                        MakeCD = c.MakeCD,
                        MakeDescription = c.MakeDescription,
                        YearCD = c.YearCD,
                        ModelCD = c.ModelCD,
                        ModelDescription = c.ModelDescription,
                        BodyCD = c.BodyCD,
                        BodyDescription = c.BodyDescription,
                        CarCD = c.CarCD,
                        CatalogCD = c.CatalogCD,
                        CatalogDescription = c.CatalogDescription
                    }).Distinct().OrderBy(c => c.CatalogDescription);
        }

        public IEnumerable<PatternModel> Patterns(string carCD, string catalogCD)
        {
            return from p in SelectorPatterns
                    where p.CarCD == carCD && p.CatalogCD == catalogCD
                    orderby p.PatternDescription
                    select new PatternModel
                    {
                        MakeCD = p.MakeCD,
                        MakeDescription = p.MakeDescription,
                        YearCD = p.YearCD,
                        ModelCD = p.ModelCD,
                        ModelDescription = p.ModelDescription,
                        BodyCD = p.BodyCD,
                        BodyDescription = p.BodyDescription,
                        CarCD = p.CarCD,
                        CatalogCD = p.CatalogCD,
                        CatalogDescription = p.CatalogDescription,
                        PatternProdCD = p.PatternProdCD,
                        PatternDescription = p.PatternDescription,
                        AirbagsDescription = p.AirbagsDescription,
                        NumberOfRows = p.NumberOfRows,
                        DrawingID = p.DrawingID
                    };
        }

        public IEnumerable<IntrColorModel> InteriorColors(string carCD, string catalogCD, string patternProdCD)
        {
            return from p in SelectorInteriors
                   where p.CarCD == carCD && p.CatalogCD == catalogCD && p.PatternProdCD == patternProdCD
                   orderby p.InteriorColorDescription
                    select new IntrColorModel
                    {
                        MakeCD = p.MakeCD,
                        MakeDescription = p.MakeDescription,
                        YearCD = p.YearCD,
                        ModelCD = p.ModelCD,
                        ModelDescription = p.ModelDescription,
                        BodyCD = p.BodyCD,
                        BodyDescription = p.BodyDescription,
                        CarCD = p.CarCD,
                        CatalogCD = p.CatalogCD,
                        CatalogDescription = p.CatalogDescription,
                        PatternProdCD = p.PatternProdCD,
                        PatternDescription = p.PatternDescription,
                        InteriorColorCD = p.InteriorColorCD,
                        InteriorColorDescription = p.InteriorColorDescription
                    };
        }

        public IEnumerable<ColorAdviceModel> ColorAdvices(string carCD, string catalogCD, string patternProdCD, string intrColorCD)
        {
            return from p in SelectorColorAdvices
                   where p.CarCD == carCD && p.CatalogCD == catalogCD && p.PatternProdCD == patternProdCD && p.InteriorColorCD == intrColorCD
                   orderby p.Advice descending, p.ColorCD
                   select new ColorAdviceModel
                   {
                       MakeCD = p.MakeCD,
                       MakeDescription = p.MakeDescription,
                       YearCD = p.YearCD,
                       ModelCD = p.ModelCD,
                       ModelDescription = p.ModelDescription,
                       BodyCD = p.BodyCD,
                       BodyDescription = p.BodyDescription,
                       CarCD = p.CarCD,
                       CatalogCD = p.CatalogCD,
                       CatalogDescription = p.CatalogDescription,
                       PatternProdCD = p.PatternProdCD,
                       PatternDescription = p.PatternDescription,
                       InteriorColorCD = p.InteriorColorCD,
                       InteriorColorDescription = p.InteriorColorDescription,
                       Advice = p.Advice,
                       ProdCD = p.ProdCD,
                       ProdDescription = p.ProdDescription,
                       ColorCD = p.ColorCD,
                       ColorDescription = p.ColorDescription
                   };
        }
    }

    public interface IMake
    {
        string MakeCD { get; set; }
        string MakeDescription { get; set; }
    }
    public interface IYear : IMake
    {
        decimal? YearCD { get; set; }
    }
    public interface IModel : IYear 
    {
        string ModelCD { get; set; }
        string ModelDescription { get; set; }
    }
    public interface IBody : IModel
    {
        string BodyCD { get; set; }
        string BodyDescription { get; set; }
    }
    public interface ICar : IBody 
    {
        string CarCD { get; set; }
    }
    public interface ICarCtlg : ICar
    {
        string CatalogCD { get; set; }
        string CatalogDescription { get; set; }
    }
    public interface ICarPtrn : ICarCtlg
    {
        string PatternProdCD { get; set; }
        string PatternDescription { get; set; }
    }
    public interface ICarPtrnIntr : ICarPtrn
    {
        string InteriorColorCD { get; set; }
        string InteriorColorDescription { get; set; }
    }
    public interface IColorAdvice : ICarPtrnIntr
    {
        string Advice { get; set; }
        string ProdCD { get; set; }
        string ProdDescription { get; set; }
        string ColorCD { get; set; }
        string ColorDescription { get; set; }
    }


}
