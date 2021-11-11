import React, {useState, useEffect} from "react";
import KinopoiskApi from "../../Api/KinopoiskApi";
import Faq from "../Views/Faq/Faq";

const FaqContainer = () => {
    const [faq, setFaq] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        (async () => {
            setLoading(true);

            const response = await KinopoiskApi.getFaqs();
            if (response === null){
                return;
            }
            setFaq(response);

            setLoading(false);
        })()
    }, [])
    
    return (
        <div>
            {
                !loading &&
                faq.map(faq => <Faq key={faq.id} loading={loading} {...faq} />)
            }
            {
                loading && 
                <div>
                    <img src="./Loading.gif" alt="Loading..."></img>
                </div>
            }
        </div>
    );
}

export default FaqContainer;