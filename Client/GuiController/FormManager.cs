namespace Client.GuiController
{
    internal sealed class FormManager
    {
        private static FormManager instance;
        internal static FormManager Instance => instance ??= new FormManager();

        private readonly Dictionary<Type, Form> openForms = new();

        private FormManager() { }

        public T? Open<T>() where T : Form, new()
        {
            Type formType = typeof(T);

            if (openForms.TryGetValue(formType, out Form? existing))
            {
                if (existing.IsDisposed)
                {
                    openForms.Remove(formType);
                    return Open<T>();
                }
                else
                {
                    existing.BringToFront();
                    existing.Focus();
                    return null;
                }
            }

            Form form = new T();
            form.FormClosed += (s, e) =>
            {
                openForms.Remove(formType);
                ShutdownAllIfLastClosed();
            };

            openForms[formType] = form;
            form.Show();

            return (T)form;
        }

        public T? Open<T>(Action<T> initializer) where T : Form, new()
        {
            Type formType = typeof(T);

            if (openForms.TryGetValue(formType, out Form? existing))
            {
                if (existing.IsDisposed)
                {
                    openForms.Remove(formType);
                    return Open(initializer);
                }
                else
                {
                    existing.BringToFront();
                    existing.Focus();
                    return null;
                }
            }

            T form = new T();
            initializer(form);

            form.FormClosed += (s, e) =>
            {
                openForms.Remove(formType);
                ShutdownAllIfLastClosed();
            };

            openForms[formType] = form;
            form.Show();

            return form;
        }

        public void Close<T>() where T : Form
        {
            Type formType = typeof(T);
            if (openForms.TryGetValue(formType, out Form? form))
            {
                form.Close();
                openForms.Remove(formType);
            }

            ShutdownAllIfLastClosed();
        }

        public void CloseAll()
        {
            foreach (var f in openForms.Values.ToList())
                f.Close();

            openForms.Clear();
        }

        public T? Get<T>() where T : Form
        {
            Type formType = typeof(T);
            if (openForms.TryGetValue(formType, out Form? form) && form is T typedForm)
                return typedForm;

            return null;
        }

        private void ShutdownAllIfLastClosed()
        {
            if (openForms.Count == 1 && openForms.ContainsKey(typeof(FrmMain)))
            {
                Communication.Instance.Disconnect();
                Application.Exit();
            }
        }
    }
}
