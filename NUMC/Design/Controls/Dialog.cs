using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace NUMC.Design.Controls
{
    public partial class Dialog : Form
    {
        #region Field Region

        private MessageBoxButtons _dialogButtons = MessageBoxButtons.Ok;
        private readonly List<Button> _buttons;

        #endregion Field Region

        #region Button Region

        protected Button btnOk;
        protected Button btnCancel;
        protected Button btnClose;
        protected Button btnYes;
        protected Button btnNo;
        protected Button btnAbort;
        protected Button btnRetry;
        protected Button btnIgnore;

        #endregion Button Region

        #region Property Region

        [Description("Determines the type of the dialog window.")]
        [DefaultValue(MessageBoxButtons.Ok)]
        public MessageBoxButtons DialogButtons
        {
            get { return _dialogButtons; }
            set
            {
                if (_dialogButtons == value)
                    return;

                _dialogButtons = value;
                SetButtons();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalButtonSize { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IButtonControl AcceptButton
        {
            get { return base.AcceptButton; }
            private set { base.AcceptButton = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IButtonControl CancelButton
        {
            get { return base.CancelButton; }
            private set { base.CancelButton = value; }
        }

        #endregion Property Region

        #region Constructor Region

        public Dialog()
        {
            InitializeComponent();

            _buttons = new List<Button>
                {
                    btnAbort, btnRetry, btnIgnore, btnOk,
                    btnCancel, btnClose, btnYes, btnNo
                };
        }

        #endregion Constructor Region

        #region Event Handler Region

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            SetButtons();
        }

        #endregion Event Handler Region

        #region Method Region

        private void SetButtons()
        {
            foreach (var btn in _buttons)
                btn.Visible = false;

            switch (_dialogButtons)
            {
                case MessageBoxButtons.Ok:
                    ShowButton(btnOk, true);
                    AcceptButton = btnOk;
                    break;

                case MessageBoxButtons.Close:
                    ShowButton(btnClose, true);
                    AcceptButton = btnClose;
                    CancelButton = btnClose;
                    break;

                case MessageBoxButtons.OkCancel:
                    ShowButton(btnOk);
                    ShowButton(btnCancel, true);
                    AcceptButton = btnOk;
                    CancelButton = btnCancel;
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    ShowButton(btnAbort);
                    ShowButton(btnRetry);
                    ShowButton(btnIgnore, true);
                    AcceptButton = btnAbort;
                    CancelButton = btnIgnore;
                    break;

                case MessageBoxButtons.RetryCancel:
                    ShowButton(btnRetry);
                    ShowButton(btnCancel, true);
                    AcceptButton = btnRetry;
                    CancelButton = btnCancel;
                    break;

                case MessageBoxButtons.YesNo:
                    ShowButton(btnYes);
                    ShowButton(btnNo, true);
                    AcceptButton = btnYes;
                    CancelButton = btnNo;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    ShowButton(btnYes);
                    ShowButton(btnNo);
                    ShowButton(btnCancel, true);
                    AcceptButton = btnYes;
                    CancelButton = btnCancel;
                    break;
            }

            SetFlowSize();
        }

        private void ShowButton(Button button, bool isLast = false)
        {
            button.SendToBack();

            if (!isLast)
                button.Margin = new Padding(0, 0, 10, 0);

            button.Visible = true;
        }

        private void SetFlowSize()
        {
            var width = flowInner.Padding.Horizontal;

            foreach (var btn in _buttons)
            {
                if (btn.Visible)
                    width += btn.Width + btn.Margin.Right;
            }

            flowInner.Width = width;
            TotalButtonSize = width;
        }

        #endregion Method Region
    }
}