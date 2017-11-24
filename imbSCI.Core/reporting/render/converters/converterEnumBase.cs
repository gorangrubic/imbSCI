namespace imbSCI.Core.reporting.render.converters
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public abstract class converterEnumBase<TTemplateEnum, TContainerEnum, TColorEnum, TSizeEnum>:converterBase
    {
        
       

        /// <summary> </summary>
        public override List<String> containerEnumValues
        {
            get
            {
                if (_containerEnumValues == null)
                {
                    _containerEnumValues = new List<String>();
                    _containerEnumValues.AddRange(Enum.GetNames(typeof(TContainerEnum)));
                }

                return _containerEnumValues;
            }
        }

        public override Type containerEnumType
        {
            get
            {
                return typeof(TContainerEnum);
            }
        }


        
        /// <summary> </summary>
        public override List<String> templateEnumValues
        {
            get
            {
                if (_templateEnumValues == null) {
                    _templateEnumValues = new List<String>();
                    _templateEnumValues.AddRange(Enum.GetNames(typeof(TTemplateEnum)));
                }

                return _templateEnumValues;
            }
        }


        public override Type templateEnumType
        {
            get
            {
                return typeof(TTemplateEnum);
            }
        }


        /// <summary>
        /// Makes Bootstrap button.
        /// </summary>
        /// <param name="btn_caption">The BTN caption.</param>
        /// <param name="btn_url">The BTN URL.</param>
        /// <param name="btn_color">Color of the BTN.</param>
        /// <param name="btn_size">Size of the BTN.</param>
        /// <returns>Bootstrap HTML</returns>
        public String GetButton(String btn_caption, String btn_url, TColorEnum btn_color, TSizeEnum btn_size)
        {
            PropertyCollection data = makeData(btn_color, btn_size, btn_caption, btn_url);
            return templates.Convert(bootstrap_component.button, data);
        }

       
        public string GetContainerOpen(TContainerEnum component, TColorEnum btn_color, TSizeEnum btn_size, String btn_caption = "", String btn_url = "")
        {
            PropertyCollection data = makeData(btn_color, btn_size, btn_caption, btn_url);
            return templates.GetContainerClose(component, data);
        }

        public string GetContainerClose(TContainerEnum component)
        {
            PropertyCollection data = new PropertyCollection();
            
            return templates.GetContainerClose(component, data);
        }

        public string GetContent(TTemplateEnum template, TColorEnum btn_color, TSizeEnum btn_size, String btn_caption="", String btn_url="")
        {
            PropertyCollection data = makeData(btn_color, btn_size, btn_caption, btn_url);
            return templates.Convert(template as Enum, data);
        }

    }

}