namespace imbSCI.Core.reporting.render.converters
{
    using imbSCI.Core.reporting.template;
    using imbSCI.Data.enums.fields;

    public class converterForBootstrap3:converterEnumBase<bootstrap_component, bootstrap_containers, bootstrap_color, bootstrap_size>
    {

        /// <summary>
        /// Represented by {{{c}}} in templates
        /// </summary>
        /// <value>
        /// The converter insert.
        /// </value>
        public override string converterInsert
        {
            get
            {
                return " markdown=\"1\" ";
            }
        }


        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public override stringTemplateConverterCollection templates
        {
            get
            {
                if (_templates == null)
                {
                    
                    _templates = new stringTemplateConverterCollection();
                    _templates.Register(bootstrap_component.button, "<a href=\"{{{btn_url}}}\" class=\"btn btn-{{{btn_color}}} btn-{{{btn_size}}}\" role=\"button\">{{{btn_caption}}}</a>");
                    _templates.Register(bootstrap_component.pageHeader, "<div class=\"page - header\" {{{c}}}><h1>{{{" + nameof(templateFieldBasic.page_name) + "}}}<small>{{{" + nameof(templateFieldBasic.page_desc)+"}}}</small></h1>");
                    _templates.Register(bootstrap_component.dropdown_menuitem, "<li class=\"nav-item\"><a class=\"nav-link\" href=\"{{{btn_url}}}\">{{{btn_caption}}}</a></li>");
                    _templates.Register(bootstrap_component.dropdown_menuheader, "<li class=\"dropdown-header\" {{{c}}}>{{{btn_caption}}}</li>");
                    _templates.Register(bootstrap_component.dropdown_menuheadlink, "<a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\" id=\"lines\">{{{btn_caption}}}<span class=\"caret\"></span></a>");


                    _templates.RegisterContainer(bootstrap_containers.alert, "<div class=\"alert alert-{{{btn_color}}} alert-dismissible\"  role=\"{{{btn_color}}}\" {{{c}}}>", "</div>");
                    _templates.RegisterContainer(bootstrap_containers.dismissibleAlert, "<div class=\"alert alert-{{{btn_color}}}\" role=\"{{{btn_color}}}\" {{{c}}}><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"{{{btn_caption}}}\"><span aria-hidden=\"true\">&times;</span></button>", "</div>");

                    _templates.RegisterContainer(bootstrap_containers.buttongroup, "<div class=\"btn-group btn-group-{{{btn_size}}}\" role=\"group\" aria-label=\"{{{btn_caption}}}\">", "</div>");

                    _templates.RegisterContainer(bootstrap_containers.buttontoolbar, "<div class=\"btn-toolbar btn-toolbar-{{{btn_size}}}\" role=\"toolbar\" aria-label=\"{{{btn_caption}}}\">", "</div>");

                    _templates.RegisterContainer(bootstrap_containers.jumbotron, "<div class=\"jumbotron\"><div class=\"container\"{{{c}}}>", "</div></div>");

                    _templates.RegisterContainer(bootstrap_containers.panel, "<div class=\"panel panel-{{{btn_color}}}\" {{{c}}} >", "</div>");
                    _templates.RegisterContainer(bootstrap_containers.panel_header, "<div class=\"panel-heading\" {{{c}}} >", "</div>");
                    _templates.RegisterContainer(bootstrap_containers.panel_footer, "<div class=\"panel-footer\" {{{c}}} >", "</div>");
                    _templates.RegisterContainer(bootstrap_containers.well, "<div class=\"well well-{{{btn_size}}}\" {{{c}}} >", "</div>");
                    _templates.RegisterContainer(bootstrap_containers.breadcrumbs, "<div class=\"breadcrumbs\" {{{c}}}>", "</div>");
                    _templates.RegisterContainer(bootstrap_containers.dropdown_ul, "<ul class=\"dropdown-menu\" aria-labelledby=\"lines\">", "</ul>");
                    _templates.RegisterContainer(bootstrap_containers.dropdown, "<li class=\"dropdown\">", "</li>");

                    _templates.RegisterContainer(bootstrap_containers.dropdown_complete, "<li class=\"dropdown\"> <a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\" id=\"lines\">{{{btn_caption}}}<span class=\"caret\"></span></a> <ul class=\"dropdown-menu\" aria-labelledby=\"lines\" {{{c}}} >", "</ul></li>");


                    // _templates.RegisterContainer(bootstrap_containers.dropdown_menuitem, "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\" id=\"lines\">{{{btn_caption}}}<span class=\"caret\"></span></a><ul class=\"dropdown-menu\" aria-labelledby=\"lines\">", "</ul></li></div>");
                }
                return _templates;
            }
        }
        
       
    }
}
