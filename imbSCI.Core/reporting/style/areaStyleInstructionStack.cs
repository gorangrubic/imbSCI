namespace imbSCI.Core.reporting.style
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core.reporting.render;
    using imbSCI.Core.reporting.style.shot;
    using imbSCI.Core.reporting.zone;
    using imbSCI.Core.extensions.data;

    /// <summary>
    /// Area Style Instruction stack - waiting for executin
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Stack{aceCommonTypes.reporting.style.areaStyleInstruction}" />
    public class areaStyleInstructionStack : Stack<areaStyleInstruction>
    {

        public areaStyleInstruction Add(IStyleInstruction shot, selectRangeArea area)
        {
            areaStyleInstruction tmp = new areaStyleInstruction(shot, area, false);
            tmp.shots.AddMultiple(tmp as IStyleInstruction);
            return tmp;
        }

        public areaStyleInstruction Add(IStyleInstruction shot, String path)
        {
            areaStyleInstruction tmp = new areaStyleInstruction(shot, path, false);
            tmp.shots.Add(tmp as IStyleInstruction);
            return tmp;
        }

        #region --- pathResolver ------- reference to dictionary to read area memory 
        private selectRangeAreaDictionary _pathResolver;
        /// <summary>
        /// reference to dictionary to read area memory
        /// </summary>
        public selectRangeAreaDictionary pathResolver
        {
            get
            {
                return _pathResolver;
            }
            protected set
            {
                _pathResolver = value;
                //OnPropertyChanged("pathResolver");
            }
        }
        #endregion

        public void execute(ITextRender render, Int32 maxSteps = 1, ILogBuilder loger = null)
        {
            Int32 step = 0;

            if (!this.Any()) {
              //  loger.log("-- areaStyleInstructionStack is empty -- execute halted");
                return;
             }

            List<areaStyleInstruction> waiting = new List<areaStyleInstruction>();
            while (Count > 0 && step < maxSteps)
            {
                if (!this.Any())
                {
                  //  loger.log("-- areaStyleInstructionStack became empty -- execute broke at "+step.ToString() + " step");
                    return;
                }
                areaStyleInstruction ins = this.Pop();
                step++;
                if (ins.resolveAreaPaths(pathResolver, ins.doAllowUnclosed))
                {

                    if (render is IDocumentRender)
                    {
                        IDocumentRender render_IDocumentRender = (IDocumentRender)render;
                        render_IDocumentRender.ApplyStyle(ins);
        
                    }

                    //render.ApplyStyle(ins);
                    break;
                }
                else
                {
                    waiting.Add(ins);
                }


            }

        //    loger.log(waiting.Count() + " Instructions is waiting for associated _area_ or _areas_ to be closed");
        }

        public areaStyleInstructionStack(selectRangeAreaDictionary __pathResolver = null)
        {

        }
    }

}