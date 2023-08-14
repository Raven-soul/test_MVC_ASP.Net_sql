
function ajaxTakeRequest(userId, booksId) {
    $.post('/Ajax/UserAddBook/', {
        'userId': userId,
        'booksId': booksId
    }, function (data) {
        location.reload();
    });
}

function ajaxDeleteRequest(userId, booksId) {
    $.post('/Ajax/UserDeleteBook/', {
        'userId': userId,
        'booksId': booksId
    }, function (data) {
        location.reload();
    });
}

function ajaxEditRequest(bookId, description) {
    $.post('/Ajax/BookEditBook/', {
        'bookId': bookId,
        'description': description
    }, function (data) {
        location.reload();
    });
}

function dataCollection(button) {
    var tokenClass = button.getAttribute("token");
    var rowList = document.querySelectorAll("input." + tokenClass);
    var booksId = "";
    var k = 0;
    rowList.forEach((cbItem) => {
        if (cbItem.checked) {
            if (k == 0) {
                booksId = booksId + cbItem.getAttribute("book-id");
                k = k + 1;
            }
            else {
                booksId = booksId + "," + cbItem.getAttribute("book-id");
            }

        }
    })
    return booksId;
}

function addBooks(button) {
    ajaxTakeRequest(button.getAttribute("user-id"), dataCollection(button));
}

function delBooks(button) {
    ajaxDeleteRequest(button.getAttribute("user-id"), dataCollection(button));
}

function editBook(button) {
    var bookId = button.getAttribute("book-id");
    var bookDescription = document.getElementById("description").value;
    ajaxEditRequest(bookId, bookDescription);
}