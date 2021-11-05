import React, {useState, useEffect} from "react";
import Faq from "../Views/Faq/Faq";

const FaqContainer = () => {
    const [faq, setFaq] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        (async () => {
            setLoading(true);

            const response = await fetch(`http://localhost:28880/api/Faq`);
            const faq = await response.json();
            setFaq(faq);

            setLoading(false);
        })()
    }, [])
    
    return (
        <div>
            {
                !loading &&
                faq.map(faq => <Faq key={faq.id} loading={loading} {...faq} />)
            }
        </div>
    );
}

export default FaqContainer;