namespace imbSCI.Core.reporting.zone
{
    using imbSCI.Core.reporting.geometrics;
    using System;

    public interface ISupportsBasicCursor
    {
        fourSideSetting padding { get; }

        fourSideSetting margin { get; }

        


        Int32 innerBottomPosition { get; }

        Int32 innerTopPosition { get; }

        Int32 innerBoxedBottomPosition { get; }

        Int32 innerBoxedTopPosition { get; }

        Int32 innerBoxedLeftPosition { get; }
        Int32 innerBoxedRightPosition { get; }

        /// <summary>
        /// Width - padding - margin: sirina u koju se upisuje sadrzaj
        /// </summary>
        Int32 innerWidth { get; }

        /// <summary>
        /// Pozicija od koje pocinje upisivanje sadrzaja
        /// </summary>
        Int32 innerLeftPosition { get; }

        /// <summary>
        /// Pozicija do koje se upisuje sadrzaj (width - padding.right, margin.right)
        /// </summary>
        Int32 innerRightPosition { get; }

        /// <summary>
        /// Sirina na kojoj se ispisuje pozadina (width-margin)
        /// </summary>
        Int32 innerBoxedWidth { get; }

        /// <summary>
        /// Visina na kojoj se ispisuje sadrzaj> height - padding - margin
        /// </summary>
        Int32 innerHeight { get; }

        /// <summary>
        /// Visina na kojoj se ispisuje pozadina> height - margin
        /// </summary>
        Int32 innerBoxedHeight { get; }

        /// <summary>
        /// maksimalna spoljna sirina formata (innerWidth+padding+margin = Windows.width) 
        /// </summary>
        Int32 width { get; set; }

        /// <summary>
        /// maksimalna spoljna visina formata (innerHeight+padding+margin=Windows.Height)
        /// </summary>
        Int32 height { get; set; }

        /// <summary>
        /// Pozicija na kojoj se zavrsava sav sadrzaj ovog bloka: Y+margin+padding+innerHeight
        /// </summary>
        Int32 outerBottomPosition { get; }

        /// <summary>
        /// Pozicija sa sve marginom> x+margin.left+padding.left+innerWidth+padding.right+margin.right
        /// </summary>
        Int32 outerRightPosition { get; }

    }
}