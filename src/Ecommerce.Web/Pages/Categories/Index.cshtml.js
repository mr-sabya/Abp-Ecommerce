$(function () {
    var l = abp.localization.getResource('Ecommerce');
    var dataTable = $('#CategoriesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                ecommerce.services.category.getList),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    },
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('DeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        ecommerce.services.category
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
            ]
        })
    );



    var createModal = new abp.ModalManager(abp.appPath + 'Categories/CreateCategoryModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewCatgoryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });


    var editModal = new abp.ModalManager(abp.appPath + 'Categories/EditCategoryModal');
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });  

});
