namespace Common.Communication
{
    public enum Operation
    {
        None,

        KreirajZdravstveniKarton,
        PretraziZdravstveniKarton,
        PromeniZdravstveniKarton,
        
        KreirajPacijent,
        PretraziPacijent,
        PromeniPacijent,
        ObrisiPacijent,

        PrijaviLekar,
        KreirajLekar,
        PretraziLekar,
        PromeniLekar,
        ObrisiLekar,

        KreirajDijagnoza,
        PretraziDijagnoza,
        PromeniDijagnoza,
        ObrisiDijagnoza,

        KreirajMesto,
        PretraziMesto,
        PromeniMesto,
        ObrisiMesto,

        UbaciSertifikat,
        PretraziSertifikat,
        PromeniSertifikat,
        ObrisiSertifikat
    }
}
