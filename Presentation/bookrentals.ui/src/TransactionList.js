import React, { useEffect, useState } from 'react';
import { format } from 'date-fns'

const TransactionList = () => {
    const host = 'https://localhost:7247/api/book/';
    const [transactions, setTransactions] = useState([]);

    const fetchData = async () => {
        await fetch(host + 'transactions',
        {
            method: 'GET',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error
                    : "Kiralama geçimişini getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            if (response.result != null && response.result.length > 0) {
                var currentDate = new Date();
                for (let i = 0; i < response.result.length; i++) {
                    const returnDate = new Date(response.result[i].returnDate);
                    if (currentDate > returnDate) {
                        const differenceTime = currentDate.getTime() - returnDate.getTime();
                        const differenceDays = differenceTime / (1000 * 3600 * 24);

                        response.result[i].deliveryExpired = true;
                        response.result[i].differenceDays = Math.round(differenceDays);
                    } else {
                        response.result[i].deliveryExpired = false;
                        response.result[i].differenceDays = 0;
                    }

                    response.result[i].rentDate = format(new Date(response.result[i].rentDate), 'dd.MM.yyyy');
                    response.result[i].returnDate = format(returnDate, 'dd.MM.yyyy');
                }
            }

            setTransactions(response.result);
        })
        .catch(error => {
            console.log(error);
            alert("Kiralama geçimişini getirilirken bir hata meydana geldi");
        });
    };

    useEffect(() => 
    {
        fetchData();
    }, []);

    return(
        <div className='container'>
            <div className='row mt-3'>
                <div className='col'>
                <table className="table table-striped table-hover table-bordered ">
                        <thead className='table-dark'>
                            <tr>
                                <th>Kitap</th>
                                <th>Yazar</th>
                                <th>Üye</th>
                                <th>Kiralama Tarihi</th>
                                <th>Teslim Tarihi</th>
                            </tr>
                        </thead>
                        <tbody>
                            {transactions.map(transaction =>
                                <tr key={transaction.id}>
                                    <td>{transaction.bookName}</td>
                                    <td>{transaction.author}</td>
                                    <td>{transaction.memberFirstName + ' ' + transaction.memberLastName}</td>
                                    <td>{transaction.rentDate}</td>
                                    <td className={transaction.deliveryExpired ? 'table-danger' : ''}>{ transaction.deliveryExpired ? transaction.returnDate + ' (' + transaction.differenceDays +' gün geçti)' : transaction.returnDate}</td>
                                </tr>)}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

export default TransactionList;