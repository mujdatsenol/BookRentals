import React, { useEffect, useState } from 'react';
// import RentButton from './RentButton';

const BookList = () => {
    const host = 'https://localhost:7247/api/book/';
    const [books, setBooks] = useState([]);
    const [form, setForm] = useState({
        name: '',
        author: '',
        isbn: 0,
        pageIndex: 1,
        pageNumber: 1,
        pageSize: 20
    });
    const [rentBook, setRentBook] = useState({
        bookId: '',
        name: '',
        author: '',
        identityNumber: '',
        returnDate: '',
    });

    const handleChange = (event) => {
        if (event.target.id == "isbn" && event.target.value == '') {
            event.target.value = 0;
        }
        
        setForm({
          ...form,
          [event.target.id]: event.target.value,
        });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        fetchData();
    };

    const fetchData = async () => {
        await fetch(host + 'search',
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(form)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error
                    : "Kitap listesi getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            setBooks(response.result.pagedList);
        })
        .catch(error => {
            console.log(error);
            alert("Kitap listesi getirilirken bir hata meydana geldi");
        });
    }

    const RentButton = ({ onClick }) => {
        return (
            <button
                type="button"
                className="btn btn-primary btn-sm"
                data-bs-toggle="modal"
                data-bs-target="#rentModal"
                onClick={onClick}>Kirala</button>
        )
    }

    const getBookForRent = (book) => {
        setRentBook(s => ({
            ...s,
            bookId: book.id,
            name: book.name,
            author: book.author
        }));
    }

    const handleRentChange = (event) => {
        setRentBook({
          ...rentBook,
          [event.target.id]: event.target.value,
        });
    };

    const handleRentSubmit = (event) => {
        event.preventDefault();
        postRentData();
    };

    const postRentData = async () => {
        if (rentBook.returnDate == '') {
            rentBook.returnDate = null;
            setRentBook(rentBook);
        }

        await fetch(host + 'rent',
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(rentBook)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error.message
                    : "Kitap kiralanırken bir hata meydana geldi";

                alert(errorMessage);
            } else {
                alert("Kiralama işlemi başarılı")
                fetchData();
            }
        })
        .catch(error => {
            console.log(error);
            alert("Kitap kiralanırken bir hata meydana geldi");
        });
    }

    useEffect(() => 
    {
        fetchData();
    }, []);
    
    return(
        <div className='container'>
            <div className='row mt-3'>
                <div className='col'>
                    <form onSubmit={handleSubmit} className="row">
                        <div className="col-3">
                            <input
                                id="name"
                                type="text"
                                className="form-control"
                                placeholder="Yazar"
                                value={form.name}
                                onChange={handleChange} />
                        </div>
                        <div className="col-3">
                            <input
                                id="author"
                                type="text"
                                className="form-control"
                                placeholder="Kitap"
                                value={form.author}
                                onChange={handleChange} />
                        </div>
                        <div className="col-3">
                            <input
                                id="isbn"
                                type="number"
                                className="form-control"
                                placeholder="Puan"
                                min={0}
                                max={10}
                                step="0.1"
                                value={form.isbn}
                                onChange={handleChange} />
                        </div>
                        <div className='col-3 d-grid'>
                            <button type="submit" className="btn btn-primary mb-3">Filtrele</button>
                        </div>
                    </form>
                    <table className="table table-striped table-hover table-bordered ">
                        <thead className='table-dark'>
                            <tr>
                                <th></th>
                                <th>Kitap</th>
                                <th>Yazar</th>
                                <th>Puan</th>
                                <th>Uygunluk</th>
                            </tr>
                        </thead>
                        <tbody>
                            {books.map(book =>
                                <tr key={book.id}>
                                    <td style={{textAlign: 'center'}}>
                                        {book.rented ? '' : <RentButton onClick={() => getBookForRent(book)}></RentButton>}
                                    </td>
                                    <td>{book.name}</td>
                                    <td>{book.author}</td>
                                    <td>{book.isbn}</td>
                                    <td className={book.rented ? 'table-warning' : 'table-success'}>
                                        {book.rented ? 'Kiralandı' : 'Uygun'}</td>
                                </tr>)}
                        </tbody>
                    </table>
                    
                    <div className="modal fade" id="rentModal" aria-labelledby="rentModalLabel" aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id="rentModalLabel">Kitap Rezervasyonu Yap</h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <form onSubmit={handleRentSubmit} >
                                        <input
                                            id="id"
                                            type="hidden"
                                            className="form-control"
                                            value={rentBook.id} />
                                        <div className="mb-3">
                                            <label htmlFor='name' className="form-label">Kitap</label>
                                            <input
                                                id="name"
                                                type="text"
                                                className="form-control"
                                                value={rentBook.name + ' - ' + rentBook.author}
                                                disabled />
                                        </div>
                                        <div className="mb-3">
                                            <label htmlFor='identityNumber' className="form-label">Üye Kimlik Numarası</label>
                                            <input
                                                id="identityNumber"
                                                type="text"
                                                className="form-control"
                                                placeholder="Kimlik Numarası"
                                                value={rentBook.identityNumber}
                                                onChange={handleRentChange} />
                                        </div>
                                        <div className="mb-3">
                                            <label htmlFor='returnDate' className="form-label">Teslim Tarihi</label>
                                            <input
                                                id="returnDate"
                                                type="date"
                                                className="form-control"
                                                placeholder="Teslim tarihi"
                                                value={rentBook.returnDate}
                                                onChange={handleRentChange} />
                                        </div>
                                    </form>
                                </div>
                                <div className="modal-footer">
                                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Kapat</button>
                                    <button type="button" className="btn btn-primary" onClick={handleRentSubmit.bind(this)}>Rezervasyon Yap</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    )
};

export default BookList;