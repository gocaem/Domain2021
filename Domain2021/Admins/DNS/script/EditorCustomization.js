function CustomizeEditor(editor) {
    var toolbar = document.querySelector('[id$=ContentPlaceHolder1_Editor1_ctl02_ctl00] .ajax__htmleditor_toolbar');

    if (!toolbar) return;

    var insertTableButton = document.createElement('button');
    insertTableButton.className = 'ajax__htmleditor_toolbar_button ajax__htmleditor_toolbar_insert_table';
    insertTableButton.title = 'Insert Table';

    insertTableButton.onclick = function () {
        var rows = prompt('Enter number of rows:', 2);
        var cols = prompt('Enter number of columns:', 2);
        if (rows && cols) {
            var tableHtml = '<table border="1">';
            for (var i = 0; i < rows; i++) {
                tableHtml += '<tr>';
                for (var j = 0; j < cols; j++) {
                    tableHtml += '<td>&nbsp;</td>';
                }
                tableHtml += '</tr>';
            }
            tableHtml += '</table>';
            editor.set_activePanel(editor.get_designPanel());
            editor.insertHTML(tableHtml);
        }
    };

    toolbar.appendChild(insertTableButton);
}

Sys.Application.add_load(function () {
    var editor = $find('ContentPlaceHolder1_Editor1_ctl02_ctl00');
    if (editor) {
        CustomizeEditor(editor);
    }
});
