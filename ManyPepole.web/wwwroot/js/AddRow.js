$(() => {
    console.log('working')
    let counter = 1;
    
    $("#add-rows").on("click", function () {
        console.log('Adding rows');
        console.log(counter);

        $("#ppl-rows").append(`<div class="row person-row" style="margin-bottom: 10px;">
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[${counter}].firstname" placeholder="First Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[${counter}].lastname" placeholder="Last Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[${counter}].age" placeholder="Age" />
                    </div>
                   
                </div>`);

        counter++;
    });
});