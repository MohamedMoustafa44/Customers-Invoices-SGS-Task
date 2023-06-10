$(document).ready(function() {

  let totalCost = 0;
  $('.add-product-button').on('click', function() {
    const newRow = `
      <tr>
        <td><input type="number" name="itemCode" required></td>
        <td><input type="text" name="itemName" required></td>
        <td><input type="number" name="qty" required></td>
        <td><input type="number" name="price" required></td>
        <td><input type="number" name="total" readonly></td>
      </tr>
    `;
    $('.product-table tbody').append(newRow);
  });

  $('.product-table').on('change', 'input[name="qty"], input[name="price"]', function() {
    const row = $(this).closest('tr');
    const qtyInput = row.find('input[name="qty"]');
    const priceInput = row.find('input[name="price"]');
    const totalInput = row.find('input[name="total"]');
    
    if (qtyInput.length && priceInput.length && totalInput.length) {
      const qty = parseFloat(qtyInput.val());
      const price = parseFloat(priceInput.val());
      const total = qty * price;
      totalInput.val(total.toFixed(2));
    }
  });

  $('.product-table').on('change', function() {
    let totalList = $('input[name="total"]');
    let sum = 0;
    totalList.each(function(){
      const value = parseFloat($(this).val());
      if(!isNaN(value)){
        sum += value;
      }
    });
    totalCost = sum;
    $('input[name="totalCost"]').val(totalCost);
    console.log(totalCost);
  });

  $('.submit-button').on('click', function(event) {
    event.preventDefault();

    const formData = {};

    formData['invoiceId'] = $('input[name="invNum"]').val();
    formData['invocieDate'] = $('input[name="invDate"]').val();
    formData['paymentMethod'] = !!$('input[name="payMethod"]:checked').val();
    formData['customer'] = $('input[name="customerName"]').val();
    formData['description'] = $('textarea[name="Dscrpt"]').val();

    const productList = [];
    $('.product-table tbody tr').each(function() {
      const productData = {};
      productData['itemCode'] = $(this).find('input[name="itemCode"]').val();
      productData['itemName'] = $(this).find('input[name="itemName"]').val();
      productData['qty'] = $(this).find('input[name="qty"]').val();
      productData['price'] = $(this).find('input[name="price"]').val();
      productData['invoiceId'] = $('input[name="invNum"]').val();

      productList.push(productData);
    });

    formData['items'] = productList;



    if(formData['paymentMethod'] == false && totalCost >= 10000){
      alert('the invoice Total should not exceed 10,000 EGP');
    }
    else{
      $.ajax({
        type: 'POST',
        url: 'https://localhost:7187/api/BuyProducts',
        data: JSON.stringify(formData),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(response) {
          alert('Invoice added successfully!');
          console.log(formData);
          $('form')[0].reset();
          $('.product-table tbody').empty();
        },
        error: function(xhr, status, error) {
          alert('Error saving invoice: ' + error);
          console.log(formData);
        }
      });
    }
  });
});