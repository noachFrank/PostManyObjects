$(() => {
    console.log('working')
    $("#add-rows").on("click", function () {
        console.log('Adding rows');
        $("#ppl-rows").append(`<div class="row person-row" style="margin-bottom: 10px;">
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[0].firstname" placeholder="First Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[0].lastname" placeholder="Last Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[0].age" placeholder="Age" />
                    </div>
                </div>`);
    });
});