import React, {useState} from 'react';
import Hero from "./Hero";

function App() {
    const [count, setCount] = useState(0);
    const increase = () => setCount(count + 10);
    const decrease = () => setCount(count - 1);
    const reset = () => setCount(0);

    return (
        <>
            <Hero/>
            <div className="container">
                <form onSubmit={e => e.preventDefault()}>
                    <h1 className={'py-2'}>State: {count}</h1>
                    <div className="btn-group">
                        <button className={'btn btn-primary'} onClick={increase}>Up</button>
                        <button className={'btn btn-primary'} onClick={decrease}>Down</button>
                        <button className={'btn btn-danger'} onClick={reset}>Reset</button>
                    </div>
                </form>
            </div>
        </>
    );
}

export default App;
