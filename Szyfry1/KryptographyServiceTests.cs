using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szyfry1
{
    public class KryptographyServiceTests
    {
    //    private KryptographyService service;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        service = new KryptographyService();
    //    }

    //    [TestCase("CRYPTOGRAPHY", 3, "CTARPORPYYGH")]
    //    [TestCase("TestowanieSzyfrow", 5, "TiweneosaSrtwzfoy")]
    //    [TestCase("Kryptografia", 8, "Krypatiofgar")]
    //    [TestCase("SiecKomputerowa", 4, "SmoioprweKueact")]
    //    [TestCase("DoZakodowaniaTojestTekst", 7, "DaoiTtZnosaajkkweeoosTdt")]
    //    public void RailfenceEncode(string input, int key, string output)
    //    {
    //        var result = service.EncodeRail(input, key);

    //        Assert.AreEqual(output, result);
    //    }
    //    [TestCase("CTARPORPYYGH", 3, "CRYPTOGRAPHY")]
    //    [TestCase("TiweneosaSrtwzfoy", 5, "TestowanieSzyfrow")]
    //    [TestCase("Krypatiofgar", 8, "Kryptografia")]
    //    [TestCase("SmoioprweKueact", 4, "SiecKomputerowa")]
    //    [TestCase("DaoiTtZnosaajkkweeoosTdt", 7, "DoZakodowaniaTojestTekst")]
    //    public void RailfenceDecode(string input, int key, string output)
    //    {
    //        var result = service.DecodeRail(input, key);

    //        Assert.AreEqual(output, result);
    //    }

    //    [TestCase("CRYPTOGRAPHY", "YPCTRRAOPGHY")]
    //    [TestCase("TestowanieSzyfrow", "stToeniweayfSrzow")]
    //    [TestCase("Kryptografia", "ypKtrraofgia")]
    //    [TestCase("SiecKomputerowa", "ecSKipuotmowear")]
    //    [TestCase("DoZakodowaniaTojestTekst", "ZaDkoowoadaTnoistjTestek")]
    //    public void MatrixShiftEncode(string input, string output)
    //    {
    //        var result = service.EncodeMatrixShift(input);

    //        Assert.AreEqual(output, result);
    //    }

    //    [TestCase("YPCTRRAOPGHY", "CRYPTOGRAPHY")]
    //    [TestCase("stToeniweayfSrzow", "TestowanieSzyfrow")]
    //    [TestCase("ypKtrraofgia", "Kryptografia")]
    //    [TestCase("ecSKipuotmowear", "SiecKomputerowa")]
    //    [TestCase("ZaDkoowoadaTnoistjTestek", "DoZakodowaniaTojestTekst")]
    //    public void MatrixShiftDecode(string input, string output)
    //    {
    //        var result = service.DecodeMatrixShift(input);

    //        Assert.AreEqual(output, result);
    //    }

    //    [TestCase("CRYPTOGRAPHY", "CONVENIENCE", "CYPTRHGYOARP")]
    //    [TestCase("TestowanieSzyfrow", "CONVENIENCE", "TzeoonSasfwwieytr")]
    //    [TestCase("Kryptografia", "CONVENIENCE", "Kaftrigyoarp")]
    //    [TestCase("SiecKomputerowa", "CONVENIENCE", "SrtKpemewouioca")]
    //    [TestCase("DoZakodowaniaTojestTekst", "CONVENIENCE", "DisaekjotnkdsZToewToatao")]
    //    public void Encode2b(string input, string key, string output)
    //    {
    //        var result = service.Encode2b(input, key);

    //        Assert.AreEqual(output, result);

    //    }

    //    [TestCase("CYPTRHGYOARP", "CONVENIENCE", "CRYPTOGRAPHY")]
    //    [TestCase("TzeoonSasfwwieytr", "CONVENIENCE", "TestowanieSzyfrow")]
    //    [TestCase("Kaftrigyoarp", "CONVENIENCE", "Kryptografia")]
    //    [TestCase("SrtKpemewouioca", "CONVENIENCE", "SiecKomputerowa")]
    //    [TestCase("DisaekjotnkdsZToewToatao", "CONVENIENCE", "DoZakodowaniaTojestTekst")]
    //    public void Decode2b(string input, string key, string output)
    //    {
    //        var result = service.Decode2b(input, key);

    //        Assert.AreEqual(output, result);

    //    }

    //    [TestCase("CRYPTOGRAPHY", "CONVENIENCE", "CRYHOARPGPYT")]
    //    [TestCase("TestowanieSzyfrow", "CONVENIENCE", "TezwSwointfaesyor")]
    //    [TestCase("Kryptografia", "CONVENIENCE", "Kraioarpgfyt")]
    //    [TestCase("SiecKomputerowa", "CONVENIENCE", "SireoupcwmteoKa")]
    //    [TestCase("DoZakodowaniaTojestTekst", "CONVENIENCE", "DoienojewtosaTtdkaZaskoT")]
    //    public void Encode2c(string input, string key, string output)
    //    {
    //        var result = service.Decode2b(input, key);

    //        Assert.AreEqual(output, result);

    //    }

    //    [TestCase("CRYHOARPGPYT", "CONVENIENCE", "CRYPTOGRAPHY")]
    //    [TestCase("TezwSwointfaesyor", "CONVENIENCE", "TestowanieSzyfrow")]
    //    [TestCase("Kraioarpgfyt", "CONVENIENCE", "Kryptografia")]
    //    [TestCase("SireoupcwmteoKa", "CONVENIENCE", "SiecKomputerowa")]
    //    [TestCase("DoienojewtosaTtdkaZaskoT", "CONVENIENCE", "DoZakodowaniaTojestTekst")]
    //    public void Decode2c(string input, string key, string output)
    //    {
    //        var result = service.Decode2b(input, key);

    //        Assert.AreEqual(output, result);

    //    }

    //    [TestCase("CRYPTOGRAPHY", 7, 5, "TURGIZVUFGCR")]
    //    [TestCase("TestowanieSzyfrow", 7, 5, "IHBIZDFSJHBYROUZD")]
    //    [TestCase("Kryptografia", 7, 5, "XURGIZVUFOJF")]
    //    [TestCase("SiecKomputerowa", 7, 5, "BJHTXZLGPIHUZDF")]
    //    [TestCase("DoZakodowaniaTojestTekst", 7, 5, "AZYFXZAZDFSJFIZQHBIIHXBI")]
    //    public void EncodeCeaser(string input, int a, int b, string output)
    //    {
    //        var result = service.EncodeCeaser(input, a, b);

    //        Assert.AreEqual(output, result);

    //    }

    //    [TestCase("TURGIZVUFGCR", 7, 5, "CRYPTOGRAPHY")]
    //    [TestCase("IHBIZDFSJHBYROUZD", 7, 5, "TestowanieSzyfrow")]
    //    [TestCase("XURGIZVUFOJF", 7, 5, "Kryptografia")]
    //    [TestCase("BJHTXZLGPIHUZDF", 7, 5, "SiecKomputerowa")]
    //    [TestCase("AZYFXZAZDFSJFIZQHBIIHXBI", 7, 5, "DoZakodowaniaTojestTekst")]
    //    public void DecodeCeaser(string input, int a, int b, string output)
    //    {
    //        var result = service.EncodeCeaser(input, a, b);

    //        Assert.AreEqual(output, result);


    //    }

    //    [TestCase("CRYPTOGRAPHY", "BREAK", "DICPDPXVAZIP")]
    //    [TestCase("TestowanieSzyfrow", "BREAK", "UvwtyxrrioTqcfbpn")]
    //    [TestCase("Kryptografia", "BREAK", "Licpdpxvapjr")]
    //    [TestCase("SiecKomputerowa", "BREAK", "TzicUpdtudfiswk")]
    //    [TestCase("DoZakodowaniaTojestTekst", "BREAK", "EfDaupuswkozeTykvwtDfbwt")]
    //    public void EncodeVigenere(string input, string key, string output)
    //    {
    //        var result = service.EncodeVigenere(input, key);

    //        Assert.AreEqual(output, result);

    //    }

    //    [TestCase("DICPDPXVAZIP", "BREAK", "CRYPTOGRAPHY")]
    //    [TestCase("UvwtyxrrioTqcfbpn", "BREAK", "TestowanieSzyfrow")]
    //    [TestCase("Licpdpxvapjr", "BREAK", "Kryptografia")]
    //    [TestCase("TzicUpdtudfiswk", "BREAK", "SiecKomputerowa")]
    //    [TestCase("EfDaupuswkozeTykvwtDfbwt", "BREAK", "DoZakodowaniaTojestTekst")]
    //    public void DecodeVigenere(string input, string key, string output)
    //    {
    //        var result = service.DecodeVigenere(input, key);

    //        Assert.AreEqual(output, result);

    //    }

    }
}
