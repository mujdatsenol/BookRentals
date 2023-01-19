import React, { useEffect, useState } from 'react';

const MemberList = () => {
    const host = 'https://localhost:7247/api/member/';
    const [members, setMembers] = useState([]);

    const fetchData = async () => {
        await fetch(host,
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
                    : "Üye listesi getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            setMembers(response.result);
        })
        .catch(error => {
            console.log(error);
            alert("Üye listesi getirilirken bir hata meydana geldi");
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
                                <th style={{width: '200px'}}>Kimlik Numarası</th>
                                <th>Adı</th>
                                <th>Soyadı</th>
                            </tr>
                        </thead>
                        <tbody>
                            {members.map(mermber =>
                                <tr key={mermber.id}>
                                    <td>{mermber.identityNumber}</td>
                                    <td>{mermber.firstName}</td>
                                    <td>{mermber.lastName}</td>
                                </tr>)}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

export default MemberList;