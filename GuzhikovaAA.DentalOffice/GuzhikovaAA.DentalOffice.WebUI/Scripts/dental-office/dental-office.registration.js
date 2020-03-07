
var patientHTML = document.getElementById('patientForm').innerHTML;
var employeeHTML = document.getElementById('employeeForm').innerHTML;
var empFullNameHTML = document.getElementById('empFullName').innerHTML;

var patientCheckbox = document.getElementById('patient');
var employeeCheckbox = document.getElementById('employee');

function start() {

    hideSection('patientForm');
    hideSection('employeeForm');
};

function generatePatientInputs() {
    showOrHide('patient', 'patientForm', patientHTML);
    duplicateSectionHide();
}

function generateEmployeeInputs() {
    showOrHide('employee', 'employeeForm', employeeHTML);
    duplicateSectionHide();
}

function duplicateSectionHide() {

    var section = document.getElementById('empFullName');

    if (patientCheckbox.checked && employeeCheckbox.checked) {

        hideSection('empFullName');

    } else {
        showSection('empFullName', empFullNameHTML);
    }
}

function ReturnBack() {
    if (history.length > 2) {
        window.history.back();

    } else {
        document.location.href = "/";
    }
};

function showOrHide(checkboxID, sectionID, elementHTML) {

    var checkbox = document.getElementById(checkboxID);

    if (checkbox.checked) {

        showSection(sectionID, elementHTML) 

    } else {

        hideSection(sectionID)
    }
}

function showSection(sectionID, elementHTML) {

    var section = document.getElementById(sectionID);
    section.innerHTML = elementHTML;
    section.style.display = "block";
}

function hideSection(sectionID) {

    var section = document.getElementById(sectionID);
    section.innerHTML = "";
    section.style.display = "none";
}


