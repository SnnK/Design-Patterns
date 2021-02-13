using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            PowerPointConverter powerPointConverter = new PowerPointConverter();
            DocxConverter docxConverter = new DocxConverter();
            PdfConverter pdfConverter = new PdfConverter();

            powerPointConverter.Next = docxConverter;
            docxConverter.Next = pdfConverter;

            powerPointConverter.Operation(new SearchCriteria { Extention = "pdf", FileName = "NewName" });

            Console.Read();
        }
    }

    public class SearchCriteria
    {
        public string Extention { get; set; }
        public string FileName { get; set; }
    }

    public abstract class Converter
    {
        public Converter()
        {
            SearchCriteriaHandler += ara;
        }

        public Converter Next { get; set; }

        private EventHandler<SearchCriteria> SearchCriteriaHandler;

        protected abstract void ara(object sender, SearchCriteria searchCriteria);

        public void Operation(SearchCriteria searchCriteria)
        {
            SearchCriteriaHandler(this, searchCriteria);
        }
    }

    public class PowerPointConverter : Converter
    {
        protected override void ara(object sender, SearchCriteria searchCriteria)
        {
            if (searchCriteria.Extention == "pptx")
            {
                Console.WriteLine($"{searchCriteria.FileName}.{searchCriteria.Extention} dosyası oluşturuldu. Dönüşüm tamamlandı.");
            }
            else
            {
                Next?.Operation(searchCriteria);
            }
        }
    }

    public class DocxConverter : Converter
    {
        protected override void ara(object sender, SearchCriteria searchCriteria)
        {
            if (searchCriteria.Extention == "docx")
            {
                Console.WriteLine($"{searchCriteria.FileName}.{searchCriteria.Extention} dosyası oluşturuldu. Dönüşüm tamamlandı.");
            }
            else
            {
                Next?.Operation(searchCriteria);
            }
        }
    }

    public class PdfConverter : Converter
    {
        protected override void ara(object sender, SearchCriteria searchCriteria)
        {
            if (searchCriteria.Extention == "pdf")
            {
                Console.WriteLine($"{searchCriteria.FileName}.{searchCriteria.Extention} dosyası oluşturuldu. Dönüşüm tamamlandı.");
            }
        }
    }
}