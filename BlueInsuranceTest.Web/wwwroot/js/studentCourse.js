setDeleteStudentCourseEvent();

$('#searchCourses').click(function (e) {
    $.ajax({
        type: 'GET',
        url: `/StudentCourse/GetCourses/?search=${$('#searchInput').val()}`,
        success: function (result) {
            createCoursesTable(result);
        }
    });
});

$('#addCourses').click(function (e) {
    let courses = $('.form-check-input:checked').map((i, el) => el.getAttribute('data-id')).map((i, e) => parseInt(e)).toArray();
    console.log(courses);
    let studentId = $('#studentId').val();
    console.log(studentId);
    $.ajax({
        type: 'POST',
        url: `/StudentCourse/AddCourses/${studentId}`,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(courses),
        success: function (result) {
            addCoursesStudentTable(result);
            $('#coursesModal').modal('toggle');
        },
        error: function (error) {
            console.log(error);
        }
    });
});

function setDeleteStudentCourseEvent() {
    $('.btn-delete-course').click(function () {
        $.ajax({
            type: 'DELETE',
            url: `/StudentCourse/DeleteStudentCourse/${this.getAttribute('data-id')}`,
            success: (result) => $(this).closest('tr').remove(),
            error: function (error) {
                console.log(error);
            }
        });
    });
}

function addCoursesStudentTable(courses) {
    $('#coursesStudentTable tr').remove();

    courses.forEach(course => {
        let tr = document.createElement('tr');
        tr.appendChild(createTd(course.code));
        tr.appendChild(createTd(course.name));
        tr.appendChild(createTd(course.teacherName));
        tr.appendChild(createTd(course.startDate));
        tr.appendChild(createTd(course.endDate));
        tr.appendChild(createTdButton(course.id));
        $('#coursesStudentTable').append(tr);
    });

    setDeleteStudentCourseEvent();
}

function createTdButton(value) {
    let td = document.createElement('td');
    td.innerHTML = `<button class="btn btn-danger btn-delete-course" data-id="${value}">Delete</button>`;
    return td;
}

function createCoursesTable(courses) {
    $('#coursesTable tr').remove();

    courses.forEach(course => {
        let tr = document.createElement('tr');
        tr.appendChild(createTdCheckBox(course.id));
        tr.appendChild(createTd(course.code));
        tr.appendChild(createTd(course.name));
        tr.appendChild(createTd(course.teacherName));
        $('#coursesTable').append(tr);
    });
}

function createTdCheckBox(value) {
    let td = document.createElement('td');
    td.innerHTML = `<div class="form-group form-check">
                        <input type="checkbox" class="form-check-input" data-id="${value}">
                    </div>`;
    return td;
}

function createTd(value) {
    let td = document.createElement('td');
    td.innerHTML = value;
    return td;
}

function formatDate(dateObject) {
    var d = new Date(dateObject);
    var day = d.getDate();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    if (day < 10) {
        day = "0" + day;
    }
    if (month < 10) {
        month = "0" + month;
    }
    var date = day + "/" + month + "/" + year;

    return date;
};