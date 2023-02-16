namespace ZalbaService.Entities
{
    public static class EntitiesEnums
    {
        public enum StatusZalbe
        {
            OTVORENA,
            USVOJENA,
            ODBIJENA
        }

        public enum TipZalbe
        {
            ZALBA_NA_ODLUKU_O_DAVANJU_NA_KORISCENJE,
            ZALBA_NA_ODLUKU_O_DAVANJU_U_ZAKUP,
            ZALBA_NA_TOK_JAVNOG_NADMETANJA

        }

        public enum RadnjaZalbe
        {
            JN_IDE_U_DRUGI_KRUG_SA_NOVIM_USLOVIMA,
            JN_IDE_U_DRUGI_KRUG_SA_STARIM_USLOVIMA,
            JN_NE_IDE_U_DRUGI_KRUG
        }
    }
}
