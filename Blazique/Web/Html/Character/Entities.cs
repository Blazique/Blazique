using System.Runtime.CompilerServices;
using static Blazique.Nodes;
using Blazique.Data;

public static class Entities
{
    public static Node amp([CallerLineNumber] int nodeId = 0) => text("&", nodeId);
    public static Node gt([CallerLineNumber] int nodeId = 0) => text(">", nodeId);
    public static Node lt([CallerLineNumber] int nodeId = 0) => text("<", nodeId);
    public static Node quot([CallerLineNumber] int nodeId = 0) => text("\\", nodeId);
    public static Node apos([CallerLineNumber] int nodeId = 0) => text("'", nodeId);
    public static Node nbsp([CallerLineNumber] int nodeId = 0) => text(" ", nodeId);
    public static Node iexcl([CallerLineNumber] int nodeId = 0) => text("¡", nodeId);
    public static Node cent([CallerLineNumber] int nodeId = 0) => text("¢", nodeId);
    public static Node pound([CallerLineNumber] int nodeId = 0) => text("£", nodeId);
    public static Node curren([CallerLineNumber] int nodeId = 0) => text("¤", nodeId);
    public static Node yen([CallerLineNumber] int nodeId = 0) => text("¥", nodeId);
    public static Node brvbar([CallerLineNumber] int nodeId = 0) => text("¦", nodeId);
    public static Node sect([CallerLineNumber] int nodeId = 0) => text("§", nodeId);
    public static Node uml([CallerLineNumber] int nodeId = 0) => text("¨", nodeId);
    public static Node copy([CallerLineNumber] int nodeId = 0) => text("©", nodeId);
    public static Node ordf([CallerLineNumber] int nodeId = 0) => text("ª", nodeId);
    public static Node laquo([CallerLineNumber] int nodeId = 0) => text("«", nodeId);
    public static Node not([CallerLineNumber] int nodeId = 0) => text("¬", nodeId);

    public static Node shy([CallerLineNumber] int nodeId = 0) => text("­", nodeId);


    public static Node reg([CallerLineNumber] int nodeId = 0) => text("®", nodeId);
    public static Node macr([CallerLineNumber] int nodeId = 0) => text("¯", nodeId);

    public static Node deg([CallerLineNumber] int nodeId = 0) => text("°", nodeId);
    public static Node plusmn([CallerLineNumber] int nodeId = 0) => text("±", nodeId);
    public static Node sup2([CallerLineNumber] int nodeId = 0) => text("²", nodeId);

    public static Node sup3([CallerLineNumber] int nodeId = 0) => text("³", nodeId);
    public static Node acute([CallerLineNumber] int nodeId = 0) => text("´", nodeId);

    public static Node micro([CallerLineNumber] int nodeId = 0) => text("µ", nodeId);
    public static Node para([CallerLineNumber] int nodeId = 0) => text("¶", nodeId);
    public static Node middot([CallerLineNumber] int nodeId = 0) => text("·", nodeId);
    public static Node cedil([CallerLineNumber] int nodeId = 0) => text("¸", nodeId);
    public static Node sup1([CallerLineNumber] int nodeId = 0) => text("¹", nodeId);
    public static Node ordm([CallerLineNumber] int nodeId = 0) => text("º", nodeId);
    public static Node raquo([CallerLineNumber] int nodeId = 0) => text("»", nodeId);
    public static Node frac14([CallerLineNumber] int nodeId = 0) => text("¼", nodeId);
    public static Node frac12([CallerLineNumber] int nodeId = 0) => text("½", nodeId);
    public static Node frac34([CallerLineNumber] int nodeId = 0) => text("¾", nodeId);
    public static Node iquest([CallerLineNumber] int nodeId = 0) => text("¿", nodeId);
    public static Node Agrave([CallerLineNumber] int nodeId = 0) => text("À", nodeId);
    public static Node Aacute([CallerLineNumber] int nodeId = 0) => text("Á", nodeId);
    public static Node Acirc([CallerLineNumber] int nodeId = 0) => text("Â", nodeId);
    public static Node Atilde([CallerLineNumber] int nodeId = 0) => text("Ã", nodeId);
    public static Node Auml([CallerLineNumber] int nodeId = 0) => text("Ä", nodeId);
    public static Node Aring([CallerLineNumber] int nodeId = 0) => text("Å", nodeId);
    public static Node AElig([CallerLineNumber] int nodeId = 0) => text("Æ", nodeId);
    public static Node Ccedil([CallerLineNumber] int nodeId = 0) => text("Ç", nodeId);
    public static Node Egrave([CallerLineNumber] int nodeId = 0) => text("È", nodeId);
    public static Node Eacute([CallerLineNumber] int nodeId = 0) => text("É", nodeId);
    public static Node Ecirc([CallerLineNumber] int nodeId = 0) => text("Ê", nodeId);
    public static Node Euml([CallerLineNumber] int nodeId = 0) => text("Ë", nodeId);
    public static Node Igrave([CallerLineNumber] int nodeId = 0) => text("Ì", nodeId);
    public static Node Iacute([CallerLineNumber] int nodeId = 0) => text("Í", nodeId);
    public static Node Icirc([CallerLineNumber] int nodeId = 0) => text("Î", nodeId);
    public static Node Iuml([CallerLineNumber] int nodeId = 0) => text("Ï", nodeId);
    public static Node ETH([CallerLineNumber] int nodeId = 0) => text("Ð", nodeId);
    public static Node Ntilde([CallerLineNumber] int nodeId = 0) => text("Ñ", nodeId);
    public static Node Ograve([CallerLineNumber] int nodeId = 0) => text("Ò", nodeId);
    public static Node Oacute([CallerLineNumber] int nodeId = 0) => text("Ó", nodeId);
    public static Node Ocirc([CallerLineNumber] int nodeId = 0) => text("Ô", nodeId);

    public static Node Otilde([CallerLineNumber] int nodeId = 0) => text("Õ", nodeId);
    public static Node Ouml([CallerLineNumber] int nodeId = 0) => text("Ö", nodeId);
    public static Node times([CallerLineNumber] int nodeId = 0) => text("×", nodeId);
    public static Node Oslash([CallerLineNumber] int nodeId = 0) => text("Ø", nodeId);
    public static Node Ugrave([CallerLineNumber] int nodeId = 0) => text("Ù", nodeId);
    public static Node Uacute([CallerLineNumber] int nodeId = 0) => text("Ú", nodeId);

    public static Node Ucirc([CallerLineNumber] int nodeId = 0) => text("Û", nodeId);
    public static Node Uuml([CallerLineNumber] int nodeId = 0) => text("Ü", nodeId);
    public static Node Yacute([CallerLineNumber] int nodeId = 0) => text("Ý", nodeId);
    public static Node THORN([CallerLineNumber] int nodeId = 0) => text("Þ", nodeId);
    public static Node szlig([CallerLineNumber] int nodeId = 0) => text("ß", nodeId);
    public static Node agrave([CallerLineNumber] int nodeId = 0) => text("à", nodeId);
    public static Node aacute([CallerLineNumber] int nodeId = 0) => text("á", nodeId);
    public static Node acirc([CallerLineNumber] int nodeId = 0) => text("â", nodeId);
    public static Node atilde([CallerLineNumber] int nodeId = 0) => text("ã", nodeId);
    public static Node auml([CallerLineNumber] int nodeId = 0) => text("ä", nodeId);
    public static Node aring([CallerLineNumber] int nodeId = 0) => text("å", nodeId);
    public static Node aelig([CallerLineNumber] int nodeId = 0) => text("æ", nodeId);
    public static Node ccedil([CallerLineNumber] int nodeId = 0) => text("ç", nodeId);
    public static Node egrave([CallerLineNumber] int nodeId = 0) => text("è", nodeId);
    public static Node eacute([CallerLineNumber] int nodeId = 0) => text("é", nodeId);
    public static Node ecirc([CallerLineNumber] int nodeId = 0) => text("ê", nodeId);
    public static Node euml([CallerLineNumber] int nodeId = 0) => text("ë", nodeId);
    public static Node igrave([CallerLineNumber] int nodeId = 0) => text("ì", nodeId);
    public static Node iacute([CallerLineNumber] int nodeId = 0) => text("í", nodeId);
    public static Node icirc([CallerLineNumber] int nodeId = 0) => text("î", nodeId);
    public static Node iuml([CallerLineNumber] int nodeId = 0) => text("ï", nodeId);
    public static Node eth([CallerLineNumber] int nodeId = 0) => text("ð", nodeId);
    public static Node ntilde([CallerLineNumber] int nodeId = 0) => text("ñ", nodeId);
    public static Node ograve([CallerLineNumber] int nodeId = 0) => text("ò", nodeId);
    public static Node oacute([CallerLineNumber] int nodeId = 0) => text("ó", nodeId);
    public static Node ocirc([CallerLineNumber] int nodeId = 0) => text("ô", nodeId);
    public static Node otilde([CallerLineNumber] int nodeId = 0) => text("õ", nodeId);
    public static Node ouml([CallerLineNumber] int nodeId = 0) => text("ö", nodeId);
    public static Node divide([CallerLineNumber] int nodeId = 0) => text("÷", nodeId);
    public static Node oslash([CallerLineNumber] int nodeId = 0) => text("ø", nodeId);
    public static Node ugrave([CallerLineNumber] int nodeId = 0) => text("ù", nodeId);
    public static Node uacute([CallerLineNumber] int nodeId = 0) => text("ú", nodeId);
    public static Node ucirc([CallerLineNumber] int nodeId = 0) => text("û", nodeId);
    public static Node uuml([CallerLineNumber] int nodeId = 0) => text("ü", nodeId);
    public static Node yacute([CallerLineNumber] int nodeId = 0) => text("ý", nodeId);
    public static Node thorn([CallerLineNumber] int nodeId = 0) => text("þ", nodeId);
    public static Node yuml([CallerLineNumber] int nodeId = 0) => text("ÿ", nodeId);


}