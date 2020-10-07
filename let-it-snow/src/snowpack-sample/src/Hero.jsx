import React from 'react';

const Hero = () => {
    return (
        <div className="jumbotron jumbotron-fluid text-primary bg-secondary">
            <div className="container">
                <h1 className="display-4"><a href={'https://www.snowpack.dev'} target={'_blank'} rel={'noopener'}>Snowpack</a> @ Haxx</h1>
                <p className="lead">Sample application during <em>Let it snow</em> talk</p>
            </div>
        </div>
    );
};

export default Hero;
